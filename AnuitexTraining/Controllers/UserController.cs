using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
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
        public IEnumerable<ApplicationUser> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ApplicationUser Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        public IActionResult Add(ApplicationUser user)
        {
            service.Add(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ApplicationUser user)
        {
            service.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
