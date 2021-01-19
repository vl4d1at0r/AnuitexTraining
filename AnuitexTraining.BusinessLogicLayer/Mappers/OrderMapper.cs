using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class OrderMapper : BaseMapper<Order, OrderModel>
    {
        private readonly OrderItemMapper _orderItemMapper;
        private readonly UserMapper _userMapper;
        
        public OrderMapper(OrderItemMapper orderItemMapper, UserMapper userMapper)
        {
            _orderItemMapper = orderItemMapper;
            _userMapper = userMapper;
        }
        
        public override Order Map(OrderModel item)
        {
            return new Order
            {
                Id = item.Id,
                CreationDate = item.CreationDate ?? default,
                Date = item.Date ?? default,
                Description = item.Description,
                PaymentId = item.PaymentId,
                Status = item.Status,
                UserId = item.UserId,
                Items = _orderItemMapper.Map(item.Items)
            };
        }

        public override OrderModel Map(Order item)
        {
            return new OrderModel
            {
                Id = item.Id,
                CreationDate = item.CreationDate,
                Date = item.Date,
                Description = item.Description,
                PaymentId = item.PaymentId,
                Status = item.Status,
                UserId = item.UserId,
                Items = _orderItemMapper.Map(item.Items),
                User = _userMapper.Map(item.User)
            };
        }
    }
}