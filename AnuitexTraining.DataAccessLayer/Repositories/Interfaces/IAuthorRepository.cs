using AnuitexTraining.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        public Task<Author> GetByNameAsync(string authorName);
    }
}