using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        public bool CheckPermissions(ApplicationUser user, string roleName);
        public void AddToRole(ApplicationUser user, string roleName);
        public void SignIn(ApplicationUser user);
        public void SignOut();
    }
}
