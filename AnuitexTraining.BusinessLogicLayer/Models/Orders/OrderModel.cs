using AnuitexTraining.BusinessLogicLayer.Models.Base;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Models.Orders
{
    public class OrderModel : BaseModel
    {
        public ICollection<OrderItemModel> Items = new List<OrderItemModel>();
    }
}
