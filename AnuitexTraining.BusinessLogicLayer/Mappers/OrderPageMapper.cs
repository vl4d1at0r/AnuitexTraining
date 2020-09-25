using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.DataAccessLayer.Models;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class OrderPageMapper : BaseMapper<OrderPageModel, OrderPage>
    {
        private readonly OrderMapper _orderMapper;

        public OrderPageMapper(OrderMapper orderMapper)
        {
            _orderMapper = orderMapper;
        }

        public override OrderPageModel Map(OrderPage item)
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

        public override OrderPage Map(OrderPageModel item)
        {
            return new OrderPage
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