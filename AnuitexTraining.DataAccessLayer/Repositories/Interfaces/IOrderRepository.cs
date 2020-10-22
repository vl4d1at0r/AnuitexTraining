using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using X.PagedList;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<IPagedList<Order>> GetPageAsync(PageOptions<Order> pageOptions, bool isAdmin, long userId);
    }
}