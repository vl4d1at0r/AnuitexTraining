using AnuitexTraining.BusinessLogicLayer.Models.Base;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Models.Orders
{
    public class OrderItemModel : BaseModel
    {
        public double Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public long OrderId { get; set; }
        public int Count { get; set; }
    }
}