using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public void AddToRole(ApplicationUser user, string roleName)
        {
            _userManager.AddToRoleAsync(user, roleName);
        }

        public void SignOut(ApplicationUser user)
        {
            _userManager.UpdateSecurityStampAsync(user);
        }

        public bool CheckPermissions(ApplicationUser user, string roleName)
        {
            return _userManager.IsInRoleAsync(user, roleName).Result;
        }

        public void Add(ApplicationUser user)
        {
            db.Users.Add(user);
        }

        public void Delete(long id)
        {
            ApplicationUser user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user != null)
            {
                db.Users.Remove(user);
            }
            Save();
        }

        public ApplicationUser Get(long id)
        {
            return db.Users.AsNoTracking().FirstOrDefault(item => item.Id == id);
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

        public void ConfirmEmail(ApplicationUser user, string code)
        {
            _userManager.ConfirmEmailAsync(user, code).Wait();
        }

        public string ForgotPassword(ApplicationUser user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user).Result;
        }

        public void ResetPassword(ApplicationUser user, string code, string newPassword)
        {
            _userManager.ResetPasswordAsync(user, code, newPassword);
        }

        public string SignUp(ApplicationUser user, string password)
        {
            _userManager.CreateAsync(user, password).Wait();
            return _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
        }

        public long GetIdByUsername(string username)
        {
            return db.Users.FirstOrDefault(user => user.UserName == username).Id;
        }

        public bool Authentication(ApplicationUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password).Result;
        }
    }
}
