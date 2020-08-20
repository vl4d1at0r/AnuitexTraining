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

        public void ConfirmEmail(long id, string code)
        {
            ApplicationUser user = repository.Get(id);
            repository.ConfirmEmail(user, code);
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

        public bool SignIn(UserModel user, string password)
        {
            return repository.Authentication(user.ToDataAccessLayerEntity(), password);
        }

        public void SignOut(UserModel user)
        {
            repository.SignOut(user.ToDataAccessLayerEntity());
        }

        public void SignUp(UserModel user, string password)
        {
            string code = repository.SignUp(user.ToDataAccessLayerEntity(), password);
            EmailHelper.SendEmailConfirmationMessage(repository.GetIdByUsername(user.UserName), code, user.Email);
        }
    }
}
