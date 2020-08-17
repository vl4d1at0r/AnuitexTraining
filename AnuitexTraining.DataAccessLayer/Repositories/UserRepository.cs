using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _userManager.CreateAsync(item);
        }

        public void Delete(int id)
        {
            ApplicationUser user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                _userManager.DeleteAsync(user);
            }
        }

        public ApplicationUser Get(int id)
        {
            return _userManager.FindByIdAsync(id.ToString()).Result;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userManager.Users;
        }

        public void Update(ApplicationUser user)
        {
            db.Update(user);
        }
    }
}
