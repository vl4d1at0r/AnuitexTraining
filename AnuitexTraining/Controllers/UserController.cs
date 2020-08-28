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

        [Authorize(Roles = "Admin")]
        [HttpPost("getAll")]
        public async Task<IEnumerable<UserModel>> GetAllAsync(UserModel filter)
        {
            return await service.GetAllAsync(filter);
        }

        [Authorize]
        [HttpGet("get/{id}")]
        public async Task<UserModel> GetAsync(long id)
        {
            return await service.GetAsync(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task UpdateAsync(UserModel user)
        {
            await service.UpdateAsync(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task DeleteAsync(long id)
        {
            await service.DeleteAsync(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("block/{id}")]
        public async Task BlockAsync(long id)
        {
            await service.BlockAsync(id);
        }
    }
}
