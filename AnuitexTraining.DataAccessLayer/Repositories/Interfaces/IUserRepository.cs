using AnuitexTraining.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        public bool CheckPermissions(string roleName);
        public void AddRole(string roleName);
        public void Authorization();
        public void Authentication();
    }
}
