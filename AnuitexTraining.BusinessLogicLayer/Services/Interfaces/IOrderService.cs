using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using PagedList;
using System.Threading.Tasks;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IPagedList<OrderModel>> GetPageAsync(OrderModel filter, int page, int pageSize, bool admin, long userId);
        public Task AddAsync(OrderModel orderModel, long userId);
        public Task DeleteAsync(long id);
        public Task BuyAsync(long id, string transactionToken);
    }
}
