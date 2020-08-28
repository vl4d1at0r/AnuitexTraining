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
                user.Errors.Add(ExceptionsInfo.InvalidEmail);
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidFirstName);
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                user.Errors.Add(ExceptionsInfo.InvalidLastName);
            }
            if (user.PhoneNumber is null)
            {
                user.Errors.Add(ExceptionsInfo.InvalidPhone);
            }
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.PhoneNumber = user.PhoneNumber;
            if(user.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, user.Errors);
            }
            IdentityResult result = await _userManager.UpdateAsync(applicationUser);
            if (!result.Succeeded)
            {
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error => error.Description).ToList());
            }
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
                    user.Email.ToLower().Contains(filter.Email.ToLower()) &&
                    user.FirstName.ToLower().Contains(filter.FirstName.ToLower()) &&
                    user.LastName.ToLower().Contains(filter.LastName.ToLower()) &&
                    (user.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default)) 
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
