using AnuitexTraining.BusinessLogicLayer.Models.Users;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public bool SignIn(UserModel email, string password);
        public void SignOut(UserModel user);
        public void SignUp(UserModel user, string password);
        public void ConfirmEmail(long id, string code);
        public void ForgotPassword(UserModel user);
        public void ResetPassword(UserModel user, string code, string newPassword);
    }
}
