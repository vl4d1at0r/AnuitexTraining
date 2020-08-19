using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        public bool CheckPermissions(ApplicationUser user, string roleName);
        public void AddToRole(ApplicationUser user, string roleName);
        public void SignIn(ApplicationUser user);
        public void SignOut(ApplicationUser user);
        public string SignUp(ApplicationUser user, string password);
        public void ConfirmEmail(ApplicationUser user, string code);
        public string ForgotPassword(ApplicationUser user);
        public void ResetPassword(ApplicationUser user, string code, string newPassword);
        public long GetIdByUsername(string username);
    }
}
