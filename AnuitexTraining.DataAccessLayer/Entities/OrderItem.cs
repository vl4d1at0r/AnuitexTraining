using AnuitexTraining.DataAccessLayer.Entities.Base;
using AnuitexTraining.DataAccessLayer.Enums;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public Currency Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public double Count { get; set; }
    }
}
