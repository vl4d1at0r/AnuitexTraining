using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Constants.Constants;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> _userManager;
        private EmailProvider _emailProvider;
        private UserMapper _userMapper;

        public AccountService(UserManager<ApplicationUser> userManager, EmailProvider emailProvider, UserMapper userMapper)
        {
            _userManager = userManager;
            _emailProvider = emailProvider;
            _userMapper = userMapper;
        }

        public async Task ConfirmEmailAsync(long id, string code)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error => error.Description).ToList());
            }
            result = await _userManager.AddToRoleAsync(user, UserRole.Client.ToString("g"));
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error => error.Description).ToList());
            }
        }

        public async Task ForgotPasswordAsync(string email)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidEmail });
            }
            string userId = await _userManager.GetUserIdAsync(applicationUser);
            long id = long.Parse(userId);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
            await _emailProvider.SendPasswordResetMessageAsync(id, passwordResetToken, email);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidEmail });
            }
            return await _userManager.GetRolesAsync(user);
        }

        public async Task ResetPasswordAsync(long id, string code, string newPassword)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            IdentityResult result = await _userManager.ResetPasswordAsync(user, code, newPassword);
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error => error.Description).ToList());
            }

        }

        public async Task SignInAsync(string email, string password)
        {
            List<string> errors = new List<string>();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user is null || string.IsNullOrEmpty(password))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.WrongCredentials });
            }
            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                errors.Add(ExceptionsInfo.WrongCredentials);
            }
            if (!user.EmailConfirmed)
            {
                errors.Add(ExceptionsInfo.EmailNotConfirmed);
            }
            if (user.IsBlocked)
            {
                errors.Add(ExceptionsInfo.UserBlocked);
            }
            if (errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, errors);
            }
        }

        public async Task SignOutAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidEmail });
            }
            IdentityResult result = await _userManager.RemoveAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey);
        }

        public async Task SignUpAsync(UserModel user, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                user.Errors.Add(ExceptionsInfo.InvalidPassword);
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidFirstName);
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidLastName);
            }
            if(user.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, user.Errors);
            }
            user.PhoneNumber = "";
            user.Id = 0; // Id is setting to 0 cause of user ability to select custom id
            ApplicationUser applicationUser = _userMapper.Map(user);
            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error => error.Description).ToList());
            }
            string emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            await _emailProvider.SendEmailConfirmationMessageAsync(applicationUser.Id, emailConfirmationToken, user.Email);
        }

        public async Task UpdateRefreshTokenAsync(string email, string refreshToken)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidEmail });
            }
            await _userManager.SetAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey, refreshToken);
        }

        public async Task VerifyRefreshTokenAsync(string email, string refreshToken)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidEmail });
            }
            if (refreshToken != await _userManager.GetAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidRefreshToken });
            }
        }
    }
}
