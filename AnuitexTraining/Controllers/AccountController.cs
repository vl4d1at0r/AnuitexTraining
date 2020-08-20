using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService service;

        public AccountController(IAccountService accountService)
        {
            service = accountService;
        }

        [HttpGet]
        [Route("login")]
        public string Login([FromQuery] UserModel user, [FromQuery] string password)
        {
            if (service.SignIn(user, password))
            {
                return JwtHelper.GenerateAccessToken(user.Email);
            }
            return null;
        }

        [HttpPost]
        public IActionResult SignUp(UserModel user, string password)
        {
            service.SignUp(user, password);
            return Ok();
        }

        [HttpGet]
        [Route("confirmEmail")]
        public IActionResult ConfirmEmail([FromQuery] long id, [FromQuery] string code)
        {
            service.ConfirmEmail(id, code);
            return Ok();
        }
    }
}
