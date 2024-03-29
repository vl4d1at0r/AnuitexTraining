﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.EF.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnuitexTraining.DataAccessLayer.Repositories.EF
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<OrderItem>> GetByOrderIdAsync(long orderId)
        {
            return await _dbSet.Where(item => item.OrderId == orderId).ToListAsync();
        }
    }
}