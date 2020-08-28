using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [Route("api/printingEditions")]
    [ApiController]
    public class PrintingEditionController : Controller
    {
        private IPrintingEditionService _printingEditionService;
        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [HttpPost("getPage")]
        public async Task<IEnumerable<PrintingEditionModel>> GetPageAsync(PrintingEditionModel filter, string orderField, bool descending, int page, int pageSize)
        {
            return await _printingEditionService.GetPageAsync(filter, orderField, descending, page, pageSize);
        }
    }
}
