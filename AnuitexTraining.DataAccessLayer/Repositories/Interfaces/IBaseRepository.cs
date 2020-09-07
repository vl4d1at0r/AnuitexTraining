using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(long id);
        public Task AddAsync(T item);
        public Task AddRangeAsync(List<T> items);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(long id);
    }
}