using AnuitexTraining.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> SignInAsync(UserModel email, string password);
        public Task SignOutAsync(UserModel user);
        public Task SignUpAsync(UserModel user, string password);
        public Task ConfirmEmailAsync(long id, string code);
        public Task ForgotPasswordAsync(UserModel user);
        public Task ResetPasswordAsync(UserModel user, string code, string newPassword);
    }
}
