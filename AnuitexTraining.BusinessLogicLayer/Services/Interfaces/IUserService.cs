using AnuitexTraining.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        public Task AddAsync(UserModel user);
        public Task DeleteAsync(int id);
        public Task<UserModel> GetAsync(int id);
        public Task<IEnumerable<UserModel>> GetAllAsync();
        public Task UpdateAsync(UserModel user);
    }
}
