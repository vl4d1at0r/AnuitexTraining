using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<IPagedList<PrintingEditionModel>> GetPageAsync(PrintingEditionModel filter, string orderField, bool descending, int page, int pageSize);
    }
}
