using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using X.PagedList;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PrintingEdition>> GetPageAsync(int page, int pageSize,
            PrintingEdition filter = null, string author = null, string orderField = null, bool descending = false)
        {
            IQueryable<PrintingEdition> printingEditions = _dbSet;
            if (filter != null)
            {
                printingEditions = _dbSet.Where(item => item.Title.ToLower().Contains(filter.Title.ToLower()));
                printingEditions =
                    _dbSet.Where(item => item.Description.ToLower().Contains(filter.Description.ToLower()));
                printingEditions = _dbSet.Where(item =>
                    filter.CreationDate == null || DateTime.Compare(item.CreationDate, filter.CreationDate) == 0);
                printingEditions = _dbSet.Where(item =>
                    item.Currency == filter.Currency || filter.Currency == CurrencyType.None);
                printingEditions = _dbSet.Where(item =>
                    item.Price.ToString().Contains(filter.Price.ToString()) || filter.Price == default);
                printingEditions =
                    _dbSet.Where(item => item.Type == filter.Type || filter.Type == PrintingEditionType.None);
                printingEditions = _dbSet.Where(item =>
                    item.AuthorInPrintingEdition.Author.Name.ToLower().Contains(author.ToLower()));
            }

            if (!string.IsNullOrEmpty(orderField))
            {
                printingEditions = printingEditions.OrderBy(orderField,
                    @descending ? SortOrder.Descending.ToString() : SortOrder.Ascending.ToString());
            }

            return await printingEditions.ToPagedListAsync(page, pageSize);
        }
    }
}