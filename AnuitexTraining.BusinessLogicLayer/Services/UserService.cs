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

        public void Add(ApplicationUser user)
        {
            repository.Add(user);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Update(ApplicationUser user)
        {
            repository.Update(user);
        }

        public ApplicationUser Get(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return repository.GetAll();
        }
    }
}
