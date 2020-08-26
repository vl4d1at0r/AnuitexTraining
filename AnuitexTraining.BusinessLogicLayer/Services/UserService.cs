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
                throw new UserException(HttpStatusCode.BadRequest, result.Errors.Select(error=>error.Description).ToList()); 
            }
        }

        public async Task DeleteAsync(int id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.UserNotFound });
            }
            await _userManager.DeleteAsync(user);
        }

        public async Task UpdateAsync(UserModel user)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(user.Email);
            if (applicationUser is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.UserNotFound });
            }
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.PhoneNumber = user.PhoneNumber;
            await _userManager.UpdateAsync(applicationUser);
        }

        public async Task<UserModel> GetAsync(int id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.UserNotFound });
            }
            return _userMapper.Map(user);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _userMapper.Map(await _userManager.Users.ToListAsync());
        }
    }
}
