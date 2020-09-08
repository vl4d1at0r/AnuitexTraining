using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.DataAccessLayer.Models;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class OrderPageMapper : BaseMapper<OrderModelPageModel, OrderPageModel>
    {
        private readonly OrderMapper _orderMapper;

        public OrderPageMapper(OrderMapper orderMapper)
        {
            _orderMapper = orderMapper;
        }

        public override OrderModelPageModel Map(OrderPageModel item)
        {
            return new OrderModelPageModel
            {
                Filter = _orderMapper.Map(item.Filter),
                Admin = item.Admin,
                Page = item.Page,
                PageSize = item.PageSize,
                UserId = item.UserId
            };
        }

        public override OrderPageModel Map(OrderModelPageModel item)
        {
            return new OrderPageModel
            {
                Filter = _orderMapper.Map(item.Filter),
                Admin = item.Admin,
                Page = item.Page,
                PageSize = item.PageSize,
                UserId = item.UserId
            };
        }
    }
}