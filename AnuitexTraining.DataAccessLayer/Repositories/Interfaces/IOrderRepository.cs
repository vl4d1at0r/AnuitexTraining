using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<IEnumerable<Order>> GetPageAsync(PageOptions<Order> pageOptions, bool isAdmin, long userId);
    }
}