using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using PagedList;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<IPagedList<PrintingEditionModel>> GetPageAsync(PrintingEditionModel filter, string orderField, bool descending, int page, int pageSize);
        public Task AddAsync(PrintingEditionModel item);
        public Task DeleteAsync(long id);
        public Task UpdateAsync(PrintingEditionModel item);
        public Task<PrintingEditionModel> GetAsync(long id);
    }
}
