using AnuitexTraining.BusinessLogicLayer.Models.Users;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public void SignIn(UserModel user);
        public void SignOut(UserModel user);
        public void SignUp(UserModel user, string password);
        public void ConfirmEmail(UserModel user, string code);
        public void ForgotPassword(UserModel user);
        public void ResetPassword(UserModel user, string code, string newPassword);
    }
}
