using AnuitexTraining.DataAccessLayer.Entities.Base;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public CurrencyType Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public double Count { get; set; }
    }
}
