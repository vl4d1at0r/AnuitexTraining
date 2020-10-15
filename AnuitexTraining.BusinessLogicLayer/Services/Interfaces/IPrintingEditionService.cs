using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<PrintingEditionPageDataModel> GetPageAsync(PageModel<PrintingEditionFilterModel> pageModel);
        public Task AddAsync(PrintingEditionModel model);
        public Task DeleteAsync(long id);
        public Task UpdateAsync(PrintingEditionModel model);
        public Task<PrintingEditionModel> GetAsync(long id);
    }
}