using AnuitexTraining.DataAccessLayer.Entities.Base;
using AnuitexTraining.DataAccessLayer.Entities.Enums;
using System;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public long UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
