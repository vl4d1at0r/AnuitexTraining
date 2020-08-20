using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> repository;

        public UserService(IUserRepository<ApplicationUser> userRepository)
        {
            repository = userRepository;
        }

        public async Task AddAsync(UserModel user)
        {
            await repository.AddAsync(user.ToDataAccessLayerEntity());
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task UpdateAsync(UserModel user)
        {
            await repository.UpdateAsync(user.ToDataAccessLayerEntity());
        }

        public async Task<UserModel> GetAsync(int id)
        {
            return UserModel.ToBusinessLogicLayerModel(await repository.GetAsync(id));
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            List<UserModel> userModels = new List<UserModel>();
            foreach(ApplicationUser user in await repository.GetAllAsync())
            {
                userModels.Add(UserModel.ToBusinessLogicLayerModel(user));
            }
            return userModels;
        }
    }
}
