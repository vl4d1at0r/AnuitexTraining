using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Models
{
    public class OrderPageModel
    {
        public bool Admin;
        public Order Filter;
        public int Page;
        public int PageSize;
        public long UserId;
    }
}