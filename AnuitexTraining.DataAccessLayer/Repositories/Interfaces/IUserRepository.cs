using AnuitexTraining.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        public Task<bool> CheckPermissionsAsync(ApplicationUser user, string roleName);
        public Task AddToRoleAsync(ApplicationUser user, string roleName);
        public Task<bool> AuthenticationAsync(ApplicationUser user, string password);
        public Task SignOutAsync(ApplicationUser user);
        public Task<string> SignUpAsync(ApplicationUser user, string password);
        public Task ConfirmEmailAsync(ApplicationUser user, string code);
        public Task<string> ForgotPasswordAsync(ApplicationUser user);
        public Task ResetPasswordAsync(ApplicationUser user, string code, string newPassword);
        public Task<long> GetIdByUsernameAsync(string username);
    }
}
