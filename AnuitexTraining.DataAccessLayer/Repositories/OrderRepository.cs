using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetPageAsync(int page, int pageSize, long userId, bool admin, Order filter = null)
        {
            IQueryable<Order> orders = null;
            if (filter != null)
            {
                orders = _dbSet.Where(item =>
                    item.Description.ToLower().Contains(filter.Description.ToLower()) &&
                    (item.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default) &&
                    (item.Date.CompareTo(filter.Date) == 0 || filter.Date == default) &&
                    (item.PaymentId.ToString().Contains(filter.PaymentId.ToString()) || filter.PaymentId == default) &&
                    (item.UserId == filter.UserId || filter.UserId == default) &&
                    (item.Status == filter.Status || filter.Status == OrderStatus.None));
            }
            else
            {
                orders = _dbSet;
            }
            if (!admin)
            {
                orders = orders.Where(item => item.UserId == userId);
            }

            return (await orders.ToListAsync()).ToPagedList(page, pageSize);
        }
    }
}
