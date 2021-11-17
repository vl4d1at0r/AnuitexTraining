using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<PageDataModel<OrderModel>> GetPageAsync(PageModel<OrderModel> orderPageModel, bool admin, long userId);
        public Task DeleteAsync(long id);
        public Task<long> BuyAsync(OrderModel orderModel);
        public Task<long> BuyExistingAsync(long id, string token);
    }
}