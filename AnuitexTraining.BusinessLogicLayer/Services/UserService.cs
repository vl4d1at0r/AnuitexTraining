using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private UserMapper _userMapper;

        public UserService(UserManager<ApplicationUser> userManager, UserMapper userMapper)
        {
            _userManager = userManager;
            _userMapper = userMapper;
        }

        public async Task AddAsync(UserModel user, string password)
        {
            ApplicationUser applicationUser = _userMapper.Map(user);
            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            List<IdentityError> identityErrors = result.Errors.ToList();
            foreach (IdentityError error in identityErrors)
            {
                user.Errors.Add(error.Description);
            }
            if (user.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, user.Errors);
            }
        }

        public async Task DeleteAsync(int id)
        {
            List<string> errors = new List<string>();
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            IdentityResult result = await _userManager.DeleteAsync(user);
            List<IdentityError> identityErrors = result.Errors.ToList();
            foreach (IdentityError error in identityErrors)
            {
                errors.Add(error.Description);
            }
            if (errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, errors);
            }
        }

        public async Task UpdateAsync(UserModel user)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(user.Email);
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.UserName = user.UserName;
            applicationUser.PhoneNumber = user.PhoneNumber;
            await _userManager.UpdateAsync(applicationUser);
        }

        public async Task<UserModel> GetAsync(int id)
        {
            return _userMapper.Map(await _userManager.FindByIdAsync(id.ToString()));
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _userMapper.Map(await _userManager.Users.ToListAsync());
        }
    }
}
