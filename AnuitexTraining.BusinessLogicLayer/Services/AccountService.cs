using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
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
            await _userManager.ConfirmEmailAsync(user, code);
            await _userManager.AddToRoleAsync(user, UserRole.Client.ToString("G"));
        }

        public async Task ForgotPasswordAsync(string email)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);
            string userId = await _userManager.GetUserIdAsync(applicationUser);
            long id = long.Parse(userId);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
            await _emailProvider.SendPasswordResetMessageAsync(id, passwordResetToken, email);
        }

        public async Task<string> GetRefreshTokenAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            return await _userManager.GetAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task ResetPasswordAsync(long id, string code, string newPassword)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.ResetPasswordAsync(user, code, newPassword);
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task SignOutAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            await _userManager.RemoveAuthenticationTokenAsync(user, AuthOptions.Issuer, AuthOptions.RefreshTokenKey);
        }

        public async Task SignUpAsync(UserModel user, string password)
        {
            ApplicationUser applicationUser = _userMapper.Map(user);
            await _userManager.CreateAsync(applicationUser, password);
            string emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            await _emailProvider.SendEmailConfirmationMessageAsync(applicationUser.Id, emailConfirmationToken, user.Email);
        }

        public async Task UpdateRefreshTokenAsync(string email, string refreshToken)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            await _userManager.SetAuthenticationTokenAsync(user, AuthOptions.Issuer, "refreshToken", refreshToken);
        }
    }
}
