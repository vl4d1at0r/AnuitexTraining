using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.EF.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AnuitexTraining.DataAccessLayer.Repositories.EF
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Author>> GetByNamesAsync(List<string> authors)
        {
            return await _dbSet.Where(item => authors.Contains(item.Name)).ToListAsync();
        }

        public async Task<IPagedList<Author>> GetPageAsync(PageOptions<Author> pageOptions)
        {
            IQueryable<Author> authors = _dbSet.Include(item => item.AuthorInPrintingEditions)
                .ThenInclude(item => item.PrintingEdition);
            if (pageOptions.Filter != null)
            {
                authors = authors.Where(item =>
                    item.Name.ToLower().Contains(pageOptions.Filter.Name.ToLower()));
            }

            if (pageOptions.SortOrder != SortOrder.Unspecified)
            {
                authors = authors.OrderBy($"{pageOptions.SortField} {pageOptions.SortOrder.ToString()}");
            }

            return await authors.ToPagedListAsync(pageOptions.Page, pageOptions.PageSize);
        }
    }
}