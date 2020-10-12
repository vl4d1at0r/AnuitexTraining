using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using static AnuitexTraining.Shared.Enums.Enums;
using X.PagedList;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseRepository<PrintingEdition>
    {
        public Task<IPagedList<PrintingEdition>> GetPageAsync(PageOptions<PrintingEditionFilter> pageOptions);
        public Task<PriceRange> GetPriceRangeAsync(CurrencyType currencyType);
    }
}