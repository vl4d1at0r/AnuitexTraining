using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Users;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public Task SignInAsync(string email, string password);
        public Task SignOutAsync(string email);
        public Task SignUpAsync(UserModel user);
        public Task<object> ConfirmEmailAsync(long id, string code);
        public Task ForgotPasswordAsync(string email);
        public Task UpdateRefreshTokenAsync(string email, string refreshToken);
        public Task<string> GetRoleAsync(string email);
        public Task VerifyRefreshTokenAsync(string email, string refreshToken);
        public Task<long> GetIdAsync(string email);
        public Task ChangeEmailAsync(long id, string email, string code);
    }
}