using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderModel>> GetPageAsync(PageModel<OrderModel> orderPageModel, bool admin, long userId);
        public Task DeleteAsync(long id);
        public Task BuyAsync(OrderModel orderModel);
    }
}