using System.Collections.Generic;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
