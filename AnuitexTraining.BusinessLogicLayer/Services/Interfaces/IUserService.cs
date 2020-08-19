using AnuitexTraining.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        public void Add(UserModel user);
        public void Delete(int id);
        public UserModel Get(int id);
        public IEnumerable<UserModel> GetAll();
        public void Update(UserModel user);
    }
}
