using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("get/{id}")]
        public async Task<AuthorModel> GetAsync(long id)
        {
            return await _authorService.GetAsync(id);
        }

        [HttpPost("getPage")]
        public async Task<PageDataModel<AuthorModel>> GetPageAsync(PageModel<AuthorModel> pageModel)
        {
            return await _authorService.GetPageAsync(pageModel);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task AddAsync(AuthorModel author)
        {
            await _authorService.AddAsync(author);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(long id)
        {
            await _authorService.DeleteAsync(id);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task UpdateAsync(AuthorModel author)
        {
            await _authorService.UpdateAsync(author);
        }
    }
}