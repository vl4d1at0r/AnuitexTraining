using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Users;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        public Task DeleteAsync(long id);
        public Task<UserModel> GetAsync(long id);
        public Task<object> GetAllAsync(UserPageModel pageModel);
        public Task UpdateAsync(UserModel user, bool force);
        public Task BlockAsync(long id);
    }
}