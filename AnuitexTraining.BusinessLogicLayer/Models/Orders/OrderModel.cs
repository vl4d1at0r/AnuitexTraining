using AnuitexTraining.BusinessLogicLayer.Models.Base;
using System;
using System.Collections.Generic;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Models.Orders
{
    public class OrderModel : BaseModel
    {
        public List<OrderItemModel> Items { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public long PaymentId { get; set; }

        public OrderModel() : base()
        {
            Items = new List<OrderItemModel>();
        }
    }
}