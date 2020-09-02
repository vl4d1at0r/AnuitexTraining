using AnuitexTraining.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        public Task<List<OrderItem>> GetByOrderIdAsync(long orderId);
    }
}
