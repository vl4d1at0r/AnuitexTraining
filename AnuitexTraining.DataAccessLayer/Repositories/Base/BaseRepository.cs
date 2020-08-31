using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await SaveAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(long id)
        {
            T item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
            await SaveAsync();
        }
    }
}
