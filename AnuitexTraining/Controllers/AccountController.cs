using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.PresentationLayer.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private JwtProvider _jwtProvider;

        public AccountController(IAccountService accountService, JwtProvider jwtProvider)
        {
            _accountService = accountService;
            _jwtProvider = jwtProvider;
        }

        [HttpGet("signIn")]
        public async Task<string> LoginAsync([FromQuery] string email, [FromQuery] string password)
        {
            if (await _accountService.SignInAsync(email, password))
            {
                return _jwtProvider.GenerateAccessToken(email);
            }
            return null;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUpAsync(UserModel user, string password)
        {
            await _accountService.SignUpAsync(user, password);
            return Ok();
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] long id, [FromQuery] string code)
        {
            await _accountService.ConfirmEmailAsync(id, code);
            return Ok("Confirmed successfully!");
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            await _accountService.ForgotPasswordAsync(email);
            return Ok("Password reset link sent!");
        }

        [HttpGet("resetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromQuery] long id, [FromQuery] string code, [FromQuery] string password)
        {
            await _accountService.ResetPasswordAsync(id, code, password);
            return Ok("Password successfully reset!");
        }
    }
}
