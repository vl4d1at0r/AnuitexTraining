using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Users;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        public Task DeleteAsync(long id);
        public Task<UserModel> GetAsync(long id);
        public Task<IEnumerable<UserModel>> GetAllAsync(UserModel filter);
        public Task UpdateAsync(UserModel user);
        public Task BlockAsync(long id);
    }
}