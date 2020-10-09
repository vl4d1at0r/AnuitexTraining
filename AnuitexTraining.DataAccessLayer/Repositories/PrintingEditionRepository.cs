using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Providers;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private ExchangeRateProvider _exchangeRateProvider;
        public PrintingEditionRepository(ApplicationContext context, ExchangeRateProvider exchangeRateProvider) : base(context)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }

        public async Task<IPagedList<PrintingEdition>> GetPageAsync(PageOptions<PrintingEditionFilter> pageOptions)
        {
            IQueryable<PrintingEdition> printingEditions = _dbSet.AsNoTracking().Include(item => item.AuthorInPrintingEditions)
                .ThenInclude(item => item.Author);
            if (pageOptions.Filter != null)
            {
                printingEditions = printingEditions.Where(item =>
                    item.Title.ToLower().Contains(pageOptions.Filter.Title.ToLower()) &&
                    item.Description.ToLower().Contains(pageOptions.Filter.Description.ToLower()) &&
                    (pageOptions.Filter.CreationDate == default ||
                     DateTime.Compare(item.CreationDate, pageOptions.Filter.CreationDate) == 0) &&
                    (item.Price.ToString().Contains(pageOptions.Filter.Price.ToString()) ||
                     pageOptions.Filter.Price == default) &&
                    (pageOptions.Filter.Types == default || pageOptions.Filter.Types.Contains(item.Type)));
                if (!string.IsNullOrEmpty(pageOptions.Filter.SearchString))
                {
                    var test = printingEditions.Select(item => item.AuthorInPrintingEditions.Where(x=>x.Author.Name.Contains(pageOptions.Filter.SearchString)) );
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
    }
}