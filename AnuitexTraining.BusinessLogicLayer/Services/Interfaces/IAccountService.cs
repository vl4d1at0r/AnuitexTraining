using AnuitexTraining.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public Task SignInAsync(string email, string password);
        public Task SignOutAsync(string email);
        public Task SignUpAsync(UserModel user, string password);
        public Task ConfirmEmailAsync(long id, string code);
        public Task ForgotPasswordAsync(string email);
        public Task ResetPasswordAsync(long id, string code, string newPassword);
        public Task UpdateRefreshTokenAsync(string email, string refreshToken);
        public Task<string> GetRoleAsync(string email);
        public Task VerifyRefreshTokenAsync(string email, string refreshToken);
        public Task<long> GetIdAsync(string email);
    }
}
