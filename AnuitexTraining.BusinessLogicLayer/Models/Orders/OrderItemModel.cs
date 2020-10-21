using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Models.Orders
{
    public class OrderItemModel : BaseModel
    {
        public double Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public PrintingEditionModel PrintingEdition { get; set; }
        public long OrderId { get; set; }
        public int Count { get; set; }
    }
}