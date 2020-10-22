using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class OrderItemMapper : BaseMapper<OrderItem, OrderItemModel>
    {
        private readonly PrintingEditionMapper _printingEditionMapper;
        
        public OrderItemMapper()
        {
            _printingEditionMapper = new PrintingEditionMapper();
        }
        
        public override OrderItem Map(OrderItemModel item)
        {
            return new OrderItem
            {
                Id = item.Id,
                Amount = item.Amount,
                Count = item.Count,
                CreationDate = item.CreationDate ?? default,
                Currency = item.Currency,
                OrderId = item.OrderId,
                PrintingEditionId = item.PrintingEditionId
            };
        }

        public override OrderItemModel Map(OrderItem item)
        {
            return new OrderItemModel
            {
                Id = item.Id,
                Amount = item.Amount,
                Count = item.Count,
                CreationDate = item.CreationDate,
                Currency = item.Currency,
                OrderId = item.OrderId,
                PrintingEditionId = item.PrintingEditionId,
                PrintingEdition = _printingEditionMapper.Map(item.PrintingEdition)
            };
        }
    }
}