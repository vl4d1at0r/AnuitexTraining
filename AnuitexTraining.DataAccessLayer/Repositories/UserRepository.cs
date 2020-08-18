using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository<ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public UserRepository(ApplicationContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void AddToRole(ApplicationUser item, string roleName)
        {
            _userManager.AddToRoleAsync(item, roleName);
        }

        public void SignOut()
        {
            _signInManager.SignOutAsync();
        }

        public void SignIn(ApplicationUser item)
        {
            _signInManager.SignInAsync(item, false);
        }

        public bool CheckPermissions(ApplicationUser item, string roleName)
        {
            return _userManager.IsInRoleAsync(item, roleName).Result;
        }

        public void Add(ApplicationUser item)
        {
            db.Users.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            ApplicationUser user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                db.Users.Remove(user);
            }
            Save();
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
            Save();
        }
    }
}
