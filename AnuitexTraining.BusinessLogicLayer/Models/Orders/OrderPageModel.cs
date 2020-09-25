namespace AnuitexTraining.BusinessLogicLayer.Models.Orders
{
    public class OrderPageModel
    {
        public bool Admin;
        public OrderModel Filter;
        public int Page;
        public int PageSize;
        public long UserId;
    }
}