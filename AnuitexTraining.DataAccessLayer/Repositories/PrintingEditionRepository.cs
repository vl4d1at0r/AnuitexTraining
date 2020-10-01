using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
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
        public PrintingEditionRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IPagedList<PrintingEdition>> GetPageAsync(PageOptions<PrintingEdition> pageOptions)
        {
            IQueryable<PrintingEdition> printingEditions = _dbSet.Include(item => item.AuthorInPrintingEditions)
                .ThenInclude(item => item.Author);
            if (pageOptions.Filter != null)
            {
                printingEditions = printingEditions.Where(item => item.Title.ToLower().Contains(pageOptions.Filter.Title.ToLower()));
                printingEditions = 
                    printingEditions.Where(item => item.Description.ToLower().Contains(pageOptions.Filter.Description.ToLower()));
                printingEditions = printingEditions.Where(item =>
                    pageOptions.Filter.CreationDate == default || DateTime.Compare(item.CreationDate, pageOptions.Filter.CreationDate) == 0);
                printingEditions = printingEditions.Where(item =>
                    item.Currency == pageOptions.Filter.Currency || pageOptions.Filter.Currency == CurrencyType.None);
                printingEditions = printingEditions.Where(item =>
                    item.Price.ToString().Contains(pageOptions.Filter.Price.ToString()) || pageOptions.Filter.Price == default);
                printingEditions =
                    printingEditions.Where(item => item.Type == pageOptions.Filter.Type || pageOptions.Filter.Type == PrintingEditionType.None);
            }

            if (pageOptions.SortOrder != SortOrder.Unspecified)
            {
                printingEditions = printingEditions.OrderBy($"{pageOptions.SortField} {pageOptions.SortOrder.ToString()}");
            }

            return await printingEditions.ToPagedListAsync(pageOptions.Page, pageOptions.PageSize);
        }
    }
}