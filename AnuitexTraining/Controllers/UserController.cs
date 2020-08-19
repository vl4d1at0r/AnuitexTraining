using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        public IEnumerable<UserModel> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        public IActionResult Add(UserModel user)
        {
            service.Add(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UserModel user)
        {
            service.Update(user);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
