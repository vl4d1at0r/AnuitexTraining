using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnuitexTraining.DataAccessLayer.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await SaveAsync();
        }

        public async Task AddRangeAsync(List<T> items)
        {
            await _dbSet.AddRangeAsync(items);
            await SaveAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}