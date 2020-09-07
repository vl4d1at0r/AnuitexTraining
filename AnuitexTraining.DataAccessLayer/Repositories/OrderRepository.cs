using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Core;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetPageAsync(int page, int pageSize, long userId, bool admin,
            Order filter = null)
        {
            IQueryable<Order> orders = _dbSet;
            if (filter != null)
            {
                orders = _dbSet.Where(item => item.Description.ToLower().Contains(filter.Description.ToLower()));
                orders = _dbSet.Where(item => item.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default);
                orders = _dbSet.Where(item => item.Date.CompareTo(filter.Date) == 0 || filter.Date == default);
                orders = _dbSet.Where(item => item.PaymentId.ToString().Contains(filter.PaymentId.ToString()) || filter.PaymentId == default);
                orders = _dbSet.Where(item => item.UserId == filter.UserId || filter.UserId == default);
                orders = _dbSet.Where(item => item.Status == filter.Status || filter.Status == OrderStatus.None);
            }

            if (!admin)
            {
                orders = orders.Where(item => item.UserId == userId);
            }

            return (await orders.ToListAsync()).ToPagedList(page, pageSize);
        }
    }
}