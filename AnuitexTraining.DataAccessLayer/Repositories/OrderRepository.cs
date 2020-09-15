using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using X.PagedList;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetPageAsync(OrderPageModel orderPageModel)
        {
            IQueryable<Order> orders = _dbSet;
            if (orderPageModel.Filter != null)
            {
                orders = _dbSet.Where(item =>
                    item.Description.ToLower().Contains(orderPageModel.Filter.Description.ToLower()));
                orders = _dbSet.Where(item =>
                    item.CreationDate.CompareTo(orderPageModel.Filter.CreationDate) == 0 ||
                    orderPageModel.Filter.CreationDate == default);
                orders = _dbSet.Where(item =>
                    item.Date.CompareTo(orderPageModel.Filter.Date) == 0 || orderPageModel.Filter.Date == default);
                orders = _dbSet.Where(item =>
                    item.PaymentId.ToString().Contains(orderPageModel.Filter.PaymentId.ToString()) ||
                    orderPageModel.Filter.PaymentId == default);
                orders = _dbSet.Where(item =>
                    item.UserId == orderPageModel.Filter.UserId || orderPageModel.Filter.UserId == default);
                orders = _dbSet.Where(item =>
                    item.Status == orderPageModel.Filter.Status || orderPageModel.Filter.Status == OrderStatus.None);
            }

            if (!orderPageModel.Admin)
            {
                orders = orders.Where(item => item.UserId == orderPageModel.UserId);
            }

            return await orders.ToPagedListAsync(orderPageModel.Page, orderPageModel.PageSize);
        }
    }
}