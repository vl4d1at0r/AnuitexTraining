using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> repository;

        public UserService(IUserRepository<ApplicationUser> userRepository)
        {
            repository = userRepository;
        }

        public void Add(UserModel user)
        {
            repository.Add(user.ToDataAccessLayerEntity());
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Update(UserModel user)
        {
            repository.Update(user.ToDataAccessLayerEntity());
        }

        public UserModel Get(int id)
        {
            return UserModel.ToBusinessLogicLayerModel(repository.Get(id));
        }

        public IEnumerable<UserModel> GetAll()
        {
            List<UserModel> userModels = new List<UserModel>();
            foreach(ApplicationUser user in repository.GetAll())
            {
                userModels.Add(UserModel.ToBusinessLogicLayerModel(user));
            }
            return userModels;
        }
    }
}
