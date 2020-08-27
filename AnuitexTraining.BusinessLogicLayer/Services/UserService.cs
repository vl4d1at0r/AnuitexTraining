using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Constants.Constants;

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
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(user.Email);
            if (applicationUser != null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.EmailAlreadyTaken });
            }
            user.Id = 0; // Id is setting to 0 cause of user ability to select custom id
            applicationUser = _userMapper.Map(user);
            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error => error.Description).ToList());
            }
        }

        public async Task DeleteAsync(long id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            await _userManager.DeleteAsync(user);
        }

        public async Task UpdateAsync(UserModel user)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(user.Email);
            if (applicationUser is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidEmail });
            }
            if (string.IsNullOrEmpty(applicationUser.FirstName))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidFirstName });
            }
            if (string.IsNullOrEmpty(applicationUser.LastName))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidLastName });
            }
            if (string.IsNullOrEmpty(applicationUser.PhoneNumber))
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidPhone });
            }
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.PhoneNumber = user.PhoneNumber;
            await _userManager.UpdateAsync(applicationUser);
        }

        public async Task<UserModel> GetAsync(long id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            return _userMapper.Map(user);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync(UserModel filter)
        {
            List<ApplicationUser> users = await _userManager.Users.ToListAsync();
            users = users.Where(user =>
            {
                if (user.UserName.ToLower().Contains(filter.UserName.ToLower()) &&
                    user.Email.ToLower().Contains(filter.UserName.ToLower()) &&
                    user.FirstName.ToLower().Contains(filter.FirstName.ToLower()) &&
                    user.LastName.ToLower().Contains(filter.LastName.ToLower())) 
                {
                    return true;
                }

                return false;
            }).ToList();
            return _userMapper.Map(users);
        }

        public async Task BlockAsync(long id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            user.IsBlocked = true;
            await _userManager.UpdateAsync(user);
        }
    }
}
