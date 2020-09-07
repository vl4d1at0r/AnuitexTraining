using AnuitexTraining.DataAccessLayer.Entities.Base;
using System;
using static AnuitexTraining.Shared.Enums.Enums;

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