using System.Collections.Generic;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(long id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(long id);
    }
}
