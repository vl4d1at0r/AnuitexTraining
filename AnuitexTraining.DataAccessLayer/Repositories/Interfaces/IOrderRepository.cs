using AnuitexTraining.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<List<Order>> GetByUserIdAsync(long userId);
    }
}
