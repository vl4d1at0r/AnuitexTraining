using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Providers;
using AnuitexTraining.DataAccessLayer.Repositories.EF.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories.EF
{
    public class PrintingEditionRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private ExchangeRateProvider _exchangeRateProvider;

        public PrintingEditionRepository(ApplicationContext context, ExchangeRateProvider exchangeRateProvider) :
            base(context)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }

        public async Task<IPagedList<PrintingEdition>> GetPageAsync(PageOptions<PrintingEditionFilter> pageOptions)
        {
            double min = _exchangeRateProvider.ExchangeToUSD(pageOptions.Filter.MinPrice, pageOptions.Filter.Currency);
            double max = _exchangeRateProvider.ExchangeToUSD(pageOptions.Filter.MaxPrice, pageOptions.Filter.Currency);
            IQueryable<PrintingEdition> printingEditions = _dbSet.AsNoTracking()
                .Include(item => item.AuthorInPrintingEditions)
                .ThenInclude(item => item.Author);
            if (pageOptions.Filter != null)
            {
                printingEditions = printingEditions.Where(item =>
                    item.Title.ToLower().Contains(pageOptions.Filter.Title.ToLower()) &&
                    item.Description.ToLower().Contains(pageOptions.Filter.Description.ToLower()) &&
                    (pageOptions.Filter.CreationDate == default ||
                     DateTime.Compare(item.CreationDate, pageOptions.Filter.CreationDate) == 0) && (min - 1 <= item.Price || pageOptions.Filter.MinPrice == default) && (item.Price <= max + 1 || pageOptions.Filter.MaxPrice == default) && (pageOptions.Filter.Types == default || pageOptions.Filter.Types.Contains(item.Type)));
                if (!string.IsNullOrEmpty(pageOptions.Filter.SearchString))
                {
                    printingEditions = printingEditions.Where(item =>
                        item.AuthorInPrintingEditions.Select(authorInPrintingEdition => Microsoft.EntityFrameworkCore.EF.Functions.Like(
                            authorInPrintingEdition.Author.Name,
                            $"%{pageOptions.Filter.SearchString}%")).Contains(true) | item.Title.ToLower()
                            .Contains(pageOptions.Filter.SearchString.ToLower()));
                }
            }

            List<PrintingEdition> items = await printingEditions.ToListAsync();

            items.ForEach(item =>
            {
                item.Price = _exchangeRateProvider.Exchange(item.Currency, pageOptions.Filter.Currency, item.Price);
                item.Currency = pageOptions.Filter.Currency;
            });

            IQueryable<PrintingEdition> sortedItems = items.AsQueryable();

            if (pageOptions.SortOrder != SortOrder.Unspecified)
            {
                sortedItems = sortedItems.OrderBy($"{pageOptions.SortField} {pageOptions.SortOrder.ToString()}");
            }

            return await sortedItems.ToPagedListAsync(pageOptions.Page, pageOptions.PageSize);
        }

        public async Task<PriceRange> GetPriceRangeAsync(CurrencyType currency)
        {
            PrintingEdition min = await _dbSet.FirstOrDefaultAsync(item => item.Price == _dbSet.Min(pe=> pe.Price));
            PrintingEdition max = await _dbSet.FirstOrDefaultAsync(item => item.Price == _dbSet.Max(pe=> pe.Price));
            return new PriceRange
            {
                MinPrice = _exchangeRateProvider.Exchange(min.Currency, currency, min.Price),
                MaxPrice = _exchangeRateProvider.Exchange(max.Currency, currency, max.Price)
            };
        }

        public override async Task<PrintingEdition> GetAsync(long id)
        {
            return await _dbSet.Include(item => item.AuthorInPrintingEditions)
                .ThenInclude(item => item.Author).FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}