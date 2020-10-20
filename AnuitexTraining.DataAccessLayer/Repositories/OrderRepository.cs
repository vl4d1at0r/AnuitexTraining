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

        public async Task<IEnumerable<Order>> GetPageAsync(PageOptions<Order> pageOptions, bool isAdmin, long userId)
        {
            IQueryable<Order> orders = _dbSet;
            if (pageOptions.Filter != null)
            {
                orders = orders.Where(item =>
                    item.Description.ToLower().Contains(pageOptions.Filter.Description.ToLower()));
                orders = orders.Where(item =>
                    DateTime.Compare((DateTime) item.CreationDate, (DateTime) pageOptions.Filter.CreationDate) == 0 ||
                    pageOptions.Filter.CreationDate == default);
                orders = orders.Where(item =>
                    item.Date.CompareTo(pageOptions.Filter.Date) == 0 || pageOptions.Filter.Date == default);
                orders = orders.Where(item =>
                    item.PaymentId.ToString().Contains(pageOptions.Filter.PaymentId.ToString()) ||
                    pageOptions.Filter.PaymentId == default);
                orders = orders.Where(item =>
                    item.UserId == pageOptions.Filter.UserId || pageOptions.Filter.UserId == default);
                orders = orders.Where(item =>
                    item.Status == pageOptions.Filter.Status || pageOptions.Filter.Status == OrderStatus.None);
            }

            if (!isAdmin)
            {
                orders = orders.Where(item => item.UserId == userId);
            }

            return await orders.ToPagedListAsync(pageOptions.Page, pageOptions.PageSize);
        }
    }
}