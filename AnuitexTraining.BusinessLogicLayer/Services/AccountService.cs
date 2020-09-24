using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using static AnuitexTraining.Shared.Constants.Constants;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly EmailProvider _emailProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserMapper _userMapper;
        private readonly PasswordGeneratorProvider _passwordGeneratorProvider;

        public AccountService(UserManager<ApplicationUser> userManager, EmailProvider emailProvider,
            UserMapper userMapper, PasswordGeneratorProvider passwordGeneratorProvider)
        {
            _userManager = userManager;
            _emailProvider = emailProvider;
            _userMapper = userMapper;
            _passwordGeneratorProvider = passwordGeneratorProvider;
        }

        public async Task<object> ConfirmEmailAsync(long id, string code)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest,
                    result.Errors.Select(error => error.Description).ToList());
            }

            return new {firstName = user.FirstName, lastName = user.LastName};
        }

        public async Task ForgotPasswordAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidEmail});
            }

            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
            var newPassword = _passwordGeneratorProvider.GeneratePassword(null);
            await _userManager.ResetPasswordAsync(applicationUser, passwordResetToken, newPassword);
            await _emailProvider.SendPasswordResetMessageAsync(newPassword, email);
        }

        public async Task<long> GetIdAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user.Id;
        }

        public async Task ChangeEmailAsync(long id, string email, string code)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.ChangeEmailAsync(user, email, code);
        }

        public async Task<string> GetRoleAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidEmail});
            }

            return (await _userManager.GetRolesAsync(user))[0];
        }

        public async Task SignInAsync(string email, string password)
        {
            var errors = new List<string>();
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null || string.IsNullOrEmpty(password))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.WrongCredentials});
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
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidEmail});
            }

            await _userManager.RemoveAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey);
        }

        public async Task SignUpAsync(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Password))
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

            if (user.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, user.Errors);
            }

            user.PhoneNumber = "";
            user.Id = 0; // NOTE: Id is setting to 0 cause of user ability to select custom id
            var applicationUser = _userMapper.Map(user);
            var result = await _userManager.CreateAsync(applicationUser, user.Password);
            var userNameError = result.Errors.FirstOrDefault(item => item.Code == "DuplicateUserName");
            if (userNameError != null)
            {
                userNameError.Description = "Nickname '" + user.NickName + "' is already taken";
            }
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest,
                    result.Errors.Select(error => error.Description).ToList());
            }

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            await _emailProvider.SendEmailConfirmationMessageAsync(applicationUser.Id, emailConfirmationToken,
                user.Email);
            
            result = await _userManager.AddToRoleAsync(applicationUser, UserRole.Client.ToString());
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest,
                    result.Errors.Select(error => error.Description).ToList());
            }
        }

        public async Task UpdateRefreshTokenAsync(string email, string refreshToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidEmail});
            }

            await _userManager.SetAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey,
                refreshToken);
        }

        public async Task VerifyRefreshTokenAsync(string email, string refreshToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidEmail});
            }

            if (refreshToken !=
                await _userManager.GetAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey))
            {
                throw new UserException(HttpStatusCode.BadRequest,
                    new List<string> {ExceptionsInfo.InvalidRefreshToken});
            }
        }
    }
}