using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<IEnumerable<PrintingEditionModel>> GetPageAsync(PrintingEditionModel filter, string orderField,
            bool descending, int page, int pageSize);

        public Task AddAsync(PrintingEditionModel item);
        public Task DeleteAsync(long id);
        public Task UpdateAsync(PrintingEditionModel item);
        public Task<PrintingEditionModel> GetAsync(long id);
    }
}