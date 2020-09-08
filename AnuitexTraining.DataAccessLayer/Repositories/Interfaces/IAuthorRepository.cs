using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        public Task<Author> GetByNameAsync(string authorName);
    }
}