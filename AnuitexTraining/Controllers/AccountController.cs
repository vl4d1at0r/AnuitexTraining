using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.PresentationLayer.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AnuitexTraining.Shared.Constants.Constants;

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
            await _accountService.SignInAsync(email, password);
            string accessToken = _jwtProvider.GenerateAccessToken(email, await _accountService.GetRolesAsync(email));
            string refreshToken = _jwtProvider.GenerateRefreshToken();
            await _accountService.UpdateRefreshTokenAsync(email, refreshToken);
            return new { accessToken, refreshToken };
        }

        [HttpPost("signUp")]
        public async Task SignUpAsync(UserModel user, string password)
        {
            await _accountService.SignUpAsync(user, password);
        }

        [Authorize]
        [HttpGet("signOut")]
        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync(User.FindFirst("Sub").Value);
        }

        [HttpGet("confirmEmail")]
        public async Task ConfirmEmailAsync(long id, string code)
        {
            await _accountService.ConfirmEmailAsync(id, code);
        }

        [HttpPost("forgotPassword")]
        public async Task ForgotPasswordAsync(string email)
        {
            await _accountService.ForgotPasswordAsync(email);
        }

        [HttpGet("resetPassword")]
        public async Task ResetPasswordAsync(long id, string code, string password)
        {
            await _accountService.ResetPasswordAsync(id, code, password);
        }

        [HttpGet("refreshToken")]
        public async Task<object> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            JwtSecurityToken token;
            try
            {
                token = _jwtProvider.GetValidatedExpiredAccessToken(accessToken);
            }
            catch
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidAccessToken });
            }
            string email = token.Payload.Sub;
            await _accountService.VerifyRefreshTokenAsync(email, refreshToken);
            IEnumerable<string> roles = await _accountService.GetRolesAsync(email);
            accessToken = _jwtProvider.GenerateAccessToken(email, roles);
            refreshToken = _jwtProvider.GenerateRefreshToken();
            await _accountService.UpdateRefreshTokenAsync(email, refreshToken);
            return new { accessToken, refreshToken };
        }
    }
}
