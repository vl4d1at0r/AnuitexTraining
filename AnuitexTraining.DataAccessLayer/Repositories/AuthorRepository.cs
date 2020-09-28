using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Author> GetByNameAsync(string authorName)
        {
            return await _dbSet.FirstOrDefaultAsync(item => item.Name == authorName);
        }

        public async Task<IPagedList<Author>> GetPageAsync(PageOptions<Author> page)
        {
            IQueryable<Author> authors = _dbSet;
            if (page.Filter != null)
            {
                authors = _dbSet.Where(item =>
                    item.Name.ToLower().Contains(page.Filter.Name.ToLower()));
            }

            if (page.SortOrder != SortOrder.Unspecified)
            {
                authors = authors.OrderBy(page.SortField + " " + page.SortOrder.ToString());
            }

            return await authors.ToPagedListAsync(page.Page, page.PageSize);
        }
    }
}