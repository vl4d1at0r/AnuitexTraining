using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.PresentationLayer.Providers;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<object> SignInAsync(string email, string password)
        {
            if (await _accountService.SignInAsync(email, password))
            {
                string accessToken = _jwtProvider.GenerateAccessToken(email, await _accountService.GetRolesAsync(email));
                string refreshToken = _jwtProvider.GenerateRefreshToken();
                await _accountService.UpdateRefreshTokenAsync(email, refreshToken);
                return new { accessToken, refreshToken };
            }
            return null;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUpAsync(UserModel user, string password)
        {
            await _accountService.SignUpAsync(user, password);
            return Ok();
        }

        [Authorize]
        [HttpGet("signOut")]
        public async Task<IActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync(User.FindFirst("Sub").Value);
            return Ok();
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync(long id, string code)
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
        public async Task<IActionResult> ResetPasswordAsync(long id, string code, string password)
        {
            await _accountService.ResetPasswordAsync(id, code, password);
            return Ok("Password successfully reset!");
        }

        [HttpGet("refreshToken")]
        public async Task<object> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            string email = _jwtProvider.GetValidatedExpiredAccessToken(accessToken).Payload.Sub;

            if(refreshToken == await _accountService.GetRefreshTokenAsync(email))
            {
                string newRefreshToken = _jwtProvider.GenerateRefreshToken();
                await _accountService.UpdateRefreshTokenAsync(email, newRefreshToken);
                return new { accessToken = _jwtProvider.GenerateAccessToken(email, await _accountService.GetRolesAsync(email)), refreshToken = newRefreshToken };
            }

            return null;
        }
    }
}
