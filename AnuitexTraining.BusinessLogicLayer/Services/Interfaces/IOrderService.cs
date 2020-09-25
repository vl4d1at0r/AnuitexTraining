using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderModel>> GetPageAsync(OrderPageModel orderPageModel);

        public Task AddAsync(OrderModel orderModel, long userId);
        public Task DeleteAsync(long id);
        public Task BuyAsync(long id, string transactionToken);
    }
}