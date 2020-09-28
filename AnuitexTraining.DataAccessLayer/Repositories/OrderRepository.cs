using System;
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

        public async Task<IEnumerable<Order>> GetPageAsync(PageOptions<Order> orderPage, bool admin, long userId)
        {
            IQueryable<Order> orders = _dbSet;
            if (orderPage.Filter != null)
            {
                orders = _dbSet.Where(item =>
                    item.Description.ToLower().Contains(orderPage.Filter.Description.ToLower()));
                orders = _dbSet.Where(item =>
                    DateTime.Compare((DateTime) item.CreationDate, (DateTime) orderPage.Filter.CreationDate) == 0 ||
                    orderPage.Filter.CreationDate == default);
                orders = _dbSet.Where(item =>
                    item.Date.CompareTo(orderPage.Filter.Date) == 0 || orderPage.Filter.Date == default);
                orders = _dbSet.Where(item =>
                    item.PaymentId.ToString().Contains(orderPage.Filter.PaymentId.ToString()) ||
                    orderPage.Filter.PaymentId == default);
                orders = _dbSet.Where(item =>
                    item.UserId == orderPage.Filter.UserId || orderPage.Filter.UserId == default);
                orders = _dbSet.Where(item =>
                    item.Status == orderPage.Filter.Status || orderPage.Filter.Status == OrderStatus.None);
            }

            if (!admin)
            {
                orders = orders.Where(item => item.UserId == userId);
            }

            return await orders.ToPagedListAsync(orderPage.Page, orderPage.PageSize);
        }
    }
}