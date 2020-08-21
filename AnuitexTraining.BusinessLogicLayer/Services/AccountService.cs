using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> _userManager;
        private EmailProvider _emailProvider;

        public AccountService(UserManager<ApplicationUser> userManager, EmailProvider emailProvider)
        {
            _userManager = userManager;
            _emailProvider = emailProvider;
        }

        public async Task ConfirmEmailAsync(long id, string code)
        {
            await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(id.ToString()), code);
        }

        public async Task ForgotPasswordAsync(string email)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(email);
            await _emailProvider.SendPasswordResetMessageAsync(
                long.Parse(await _userManager.GetUserIdAsync(applicationUser)), 
                await _userManager.GeneratePasswordResetTokenAsync(applicationUser), 
                applicationUser.Email);
        }

        public async Task ResetPasswordAsync(long id, string code, string newPassword)
        {
            await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(id.ToString()), code, newPassword);
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            return await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(email), password);
        }

        public async Task SignOutAsync(UserModel user)
        {
            await _userManager.UpdateSecurityStampAsync(user.ToDataAccessLayerEntity());
        }

        public async Task SignUpAsync(UserModel user, string password)
        {
            ApplicationUser applicationUser = user.ToDataAccessLayerEntity();
            await _userManager.CreateAsync(applicationUser, password);
            await _emailProvider.SendEmailConfirmationMessageAsync(
                long.Parse(await _userManager.GetUserIdAsync(user.ToDataAccessLayerEntity())), 
                await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser), 
                user.Email);
        }
    }
}
