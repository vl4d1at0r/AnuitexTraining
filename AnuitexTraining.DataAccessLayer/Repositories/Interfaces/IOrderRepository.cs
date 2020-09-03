using AnuitexTraining.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<IEnumerable<Order>> GetPageAsync(int page, int pageSize, long userId, bool admin, Order filter = null);
    }
}
