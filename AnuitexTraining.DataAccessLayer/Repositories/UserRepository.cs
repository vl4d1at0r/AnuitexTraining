using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository<ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;
        public UserRepository(ApplicationContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task SignOutAsync(ApplicationUser user)
        {
            await _userManager.UpdateSecurityStampAsync(user);
        }

        public async Task<bool> CheckPermissionsAsync(ApplicationUser user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task ConfirmEmailAsync(ApplicationUser user, string code)
        {
            await _userManager.ConfirmEmailAsync(user, code);
        }

        public async Task<string> ForgotPasswordAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task ResetPasswordAsync(ApplicationUser user, string code, string newPassword)
        {
            await _userManager.ResetPasswordAsync(user, code, newPassword);
        }

        public async Task<string> SignUpAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
        }

        public async Task<long> GetIdByUsernameAsync(string username)
        {
            return (await _dbSet.FirstOrDefaultAsync(user => user.UserName == username)).Id;
        }

        public async Task<bool> AuthenticationAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
