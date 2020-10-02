using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [Route("api/printingEditions")]
    [ApiController]
    public class PrintingEditionController : Controller
    {
        private readonly IPrintingEditionService _printingEditionService;

        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [HttpPost("getPage")]
        public async Task<PageDataModel<PrintingEditionModel>> GetPageAsync(PageModel<PrintingEditionFilterModel> pageModel)
        {
            return await _printingEditionService.GetPageAsync(pageModel);
        }

        [HttpGet("get/{id}")]
        public async Task<PrintingEditionModel> Get(long id)
        {
            return await _printingEditionService.GetAsync(id);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task AddAsync(PrintingEditionModel item)
        {
            await _printingEditionService.AddAsync(item);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(long id)
        {
            await _printingEditionService.DeleteAsync(id);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task UpdateAsync(PrintingEditionModel item)
        {
            await _printingEditionService.UpdateAsync(item);
        }
    }
}