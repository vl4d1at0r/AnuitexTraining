using System;
using System.Linq;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using AnuitexTraining.Shared.Enums;
using Microsoft.EntityFrameworkCore;

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

        public async Task<object> GetPageAsync(AuthorPage page)
        {
            IQueryable<Author> authors = _dbSet;
            if (page.Filter != null)
            {
                authors = _dbSet.Where(item =>
                    item.Name.ToLower().Contains(page.Filter.Name.ToLower()));
            }

            if (!orderPage.Admin)
            {
                orders = orders.Where(item => item.UserId == orderPage.UserId);
            }

            return await orders.ToPagedListAsync(orderPage.Page, orderPage.PageSize);
        }
    }
}