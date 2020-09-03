using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<PrintingEdition>> GetPageAsync(int page, int pageSize, PrintingEdition filter = null, string author = null, string orderField = null, bool descending = false)
        {
            IQueryable<PrintingEdition> printingEditions = null;
            if (filter != null)
            {
                printingEditions = _dbSet.Where(item =>
                        item.Title.ToLower().Contains(filter.Title.ToLower()) &&
                        item.Description.ToLower().Contains(filter.Description.ToLower()) &&
                        (item.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default) &&
                        (item.Currency == filter.Currency || filter.Currency == CurrencyType.None) &&
                        (item.Price.ToString().Contains(filter.Price.ToString()) || filter.Price == default) &&
                        (item.Type == filter.Type || filter.Type == PrintingEditionType.None) &&
                        item.AuthorInPrintingEdition.Author.Name.ToLower().Contains(author.ToLower()));
            }
            else
            {
                printingEditions = _dbSet;
            }

            if (!string.IsNullOrEmpty(orderField))
            {
                if (descending)
                {
                    printingEditions = printingEditions.OrderBy(orderField, SortOrder.Descending.ToString());
                }
                else
                {
                    printingEditions = printingEditions.OrderBy(orderField, SortOrder.Ascending.ToString());
                }
            }

            return (await printingEditions.ToListAsync()).ToPagedList(page, pageSize);
        }
    }
}
