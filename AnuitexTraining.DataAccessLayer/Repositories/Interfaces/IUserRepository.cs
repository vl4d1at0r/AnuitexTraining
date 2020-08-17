using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        public bool CheckPermissions(string roleName);
        public void AddRole(string roleName);
        public void Authorization();
        public void Authentication();
    }
}
