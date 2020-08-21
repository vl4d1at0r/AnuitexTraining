using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> repository;
        private UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            repository = userRepository;
            _userManager = userManager;
        }

        public async Task AddAsync(UserModel user, string password)
        {
            ApplicationUser applicationUser = user.ToDataAccessLayerEntity();
            await _userManager.CreateAsync(applicationUser, password);
        }

        public async Task DeleteAsync(int id)
        {
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id.ToString()));
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
            return UserModel.ToBusinessLogicLayerModel(await _userManager.FindByIdAsync(id.ToString()));
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            List<UserModel> userModels = new List<UserModel>();
            foreach(ApplicationUser user in await _userManager.Users.ToListAsync())
            {
                userModels.Add(UserModel.ToBusinessLogicLayerModel(user));
            }
            return userModels;
        }
    }
}
