using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository<ApplicationUser>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }

        public void Add(ApplicationUser user)
        {
            db.Users.Add(user);
        }

        public void AddRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public void Authentication()
        {
            throw new System.NotImplementedException();
        }

        public void Authorization()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckPermissions(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            ApplicationUser user = db.Users.FirstOrDefault(item => item.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public ApplicationUser Get(int id)
        {
            return db.Users.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.Users;
        }

        public void Update(ApplicationUser user)
        {
            db.Update(user);
        }
    }
}
