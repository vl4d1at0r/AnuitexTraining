using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task AddAsync(UserModel user, string password)
        {
            await service.AddAsync(user, password);
        }

        [HttpPut("update")]
        public async Task UpdateAsync(UserModel user)
        {
            await service.UpdateAsync(user);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
