using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IPaymentRepository _paymentRepository;
        private OrderMapper _orderMapper;
        private OrderItemMapper _orderItemMapper;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IPaymentRepository paymentRepository, OrderMapper orderMapper, OrderItemMapper orderItemMapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _paymentRepository = paymentRepository;
            _orderMapper = orderMapper;
            _orderItemMapper = orderItemMapper;
        }

        public async Task<IPagedList<OrderModel>> GetPage(OrderModel filter, int page, int pageSize)
        {
            List<Order> orders = await _orderRepository.GetAllAsync();
            orders = orders.Where(item =>
            {
                if (item.Description.ToLower().Contains(filter.Description.ToLower()) &&
                    (item.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default) &&
                    (item.Date.CompareTo(filter.Date) == 0 || filter.Date == default) &&
                    (item.PaymentId.ToString().Contains(filter.PaymentId.ToString()) || filter.PaymentId == default) &&
                    (item.UserId == filter.UserId || filter.UserId == filter.UserId == default) &&
                    (item.Status == filter.Status || filter.Status == OrderStatus.None))
                {
                    return true;
                }
                return false;
            }).ToList();
            List<OrderModel> models = _orderMapper.Map(orders);
            models.ForEach(async item => 
            {
                List<OrderItem> orderItems = await _orderItemRepository.GetByOrderIdAsync(item.Id);
                item.Items = _orderItemMapper.Map(orderItems);
            });
            return models.ToPagedList(page, pageSize);
        }

        public async Task AddAsync(OrderModel orderModel, bool admin)
        {
            await _orderRepository.AddAsync(_orderMapper.Map(orderModel));
            await _orderItemRepository.AddRangeAsync(_orderItemMapper.Map(orderModel.Items));
        }

        public async Task DeleteAsync(long id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(OrderModel orderModel)
        {
            await _orderRepository.UpdateAsync(_orderMapper.Map(orderModel));
        }
    }
}
