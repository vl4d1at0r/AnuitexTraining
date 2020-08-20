using AnuitexTraining.BusinessLogicLayer.Helpers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository<ApplicationUser> _userRepository;
        private UserManager<ApplicationUser> _userManager;

        public AccountService(IUserRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task ConfirmEmailAsync(long id, string code)
        {
            await _userRepository.ConfirmEmailAsync(await _userManager.FindByIdAsync(id.ToString()), code);
        }

        public async Task ForgotPasswordAsync(UserModel user)
        {
            string code = await _userRepository.ForgotPasswordAsync(user.ToDataAccessLayerEntity());
            EmailHelper.SendPasswordResetMessage(await _userRepository.GetIdByUsernameAsync(user.UserName), code, user.Email);
        }

        public async Task ResetPasswordAsync(UserModel user, string code, string newPassword)
        {
            await _userRepository.ResetPasswordAsync(user.ToDataAccessLayerEntity(), code, newPassword);
        }

        public async Task<bool> SignInAsync(UserModel user, string password)
        {
            return await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(user.Email), password);
        }

        public async Task SignOutAsync(UserModel user)
        {
            await _userRepository.SignOutAsync(user.ToDataAccessLayerEntity());
        }

        public async Task SignUpAsync(UserModel user, string password)
        {
            string code = await _userRepository.SignUpAsync(user.ToDataAccessLayerEntity(), password);
            EmailHelper.SendEmailConfirmationMessage(await _userRepository.GetIdByUsernameAsync(user.UserName), code, user.Email);
        }
    }
}
