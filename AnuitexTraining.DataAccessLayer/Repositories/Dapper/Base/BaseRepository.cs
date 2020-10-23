using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Dapper;
using X.PagedList;

namespace AnuitexTraining.DataAccessLayer.Repositories.Dapper.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected IDbConnection _dbConnection;
        private IEnumerable<string> _columns;
        
        public BaseRepository(IDbConnection connection)
        {
            _dbConnection = connection;
            _columns = typeof(T)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }
        
        public async Task<List<T>> GetAllAsync()
        {
            var queryResult = await _dbConnection.QueryAsync<T>($"select * from {typeof(T).Name}s");
            return await queryResult.ToListAsync();
        }

        public async Task<T> GetAsync(long id)
        {
            var queryResult = await _dbConnection.QueryFirstOrDefaultAsync<T>($"select * from {typeof(T).Name}s where id = {id}");
            return queryResult;
        }

        public async Task AddAsync(T item)
        {
            await _dbConnection.QueryAsync($"insert into {typeof(T).Name}s values ({string.Join(", ", _columns.Select(e => "@" + e))})", item);
        }

        public async Task AddRangeAsync(List<T> items)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(T item)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}