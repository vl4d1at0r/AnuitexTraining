using AnuitexTraining.BusinessLogicLayer.Helpers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository<ApplicationUser> repository;

        public AccountService(IUserRepository<ApplicationUser> userRepository)
        {
            repository = userRepository;
        }

        public void ConfirmEmail(UserModel user, string code)
        {
            repository.ConfirmEmail(user.ToDataAccessLayerEntity(), code);
        }

        public void ForgotPassword(UserModel user)
        {
            string code = repository.ForgotPassword(user.ToDataAccessLayerEntity());
            EmailHelper.SendPasswordResetMessage(repository.GetIdByUsername(user.UserName), code, user.Email);
        }

        public void ResetPassword(UserModel user, string code, string newPassword)
        {
            repository.ResetPassword(user.ToDataAccessLayerEntity(), code, newPassword);
        }

        public void SignIn(UserModel user)
        {
            repository.SignIn(user.ToDataAccessLayerEntity());
        }

        public void SignOut(UserModel user)
        {
            repository.SignOut(user.ToDataAccessLayerEntity());
        }

        public void SignUp(UserModel user, string password)
        {
            string code = repository.SignUp(user.ToDataAccessLayerEntity(), password);
            EmailHelper.SendEmailConfirmationMessage(repository.GetIdByUsername(user.UserName), code, password);
        }
    }
}
