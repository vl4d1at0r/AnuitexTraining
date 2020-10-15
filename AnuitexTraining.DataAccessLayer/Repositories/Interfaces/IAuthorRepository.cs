using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using X.PagedList;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        public Task<List<Author>> GetByNamesAsync(List<string> authors);
        public Task<IPagedList<Author>> GetPageAsync(PageOptions<Author> pageOptions);
    }
}