using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.BusinessLogicLayer.Models.Base;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<AuthorModel> GetAsync(long id);
        public Task<PageDataModel<AuthorModel>> GetPageAsync(PageModel<AuthorModel> pageModel);
        public Task AddAsync(AuthorModel item);
        public Task DeleteAsync(long id);
        public Task UpdateAsync(AuthorModel item);
    }
}