using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<AuthorModel> GetAsync(long id);
        public Task<IEnumerable<AuthorModel>> GetAllAsync();
        public Task AddAsync(AuthorModel item);
        public Task DeleteAsync(long id);
        public Task UpdateAsync(AuthorModel item);
    }
}