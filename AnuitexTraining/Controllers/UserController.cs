using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserService service;

        public UserController(IUserService userService)
        {
            service = userService;
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("get/{id}")]
        public async Task<UserModel> GetAsync(int id)
        {
            return await service.GetAsync(id);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(UserModel user, string password)
        {
            await service.AddAsync(user, password);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UserModel user)
        {
            await service.UpdateAsync(user);
            return Ok();
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
