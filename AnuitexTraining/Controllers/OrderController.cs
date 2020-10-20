using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("getPage")]
        [Authorize]
        public async Task<IEnumerable<OrderModel>> GetPageAsync(PageModel<OrderModel> pageModel)
        {
            bool admin = User.FindFirst(ClaimTypes.Role).Value == "Admin";
            long userId = long.Parse(User.FindFirst("Id").Value);
            return await _orderService.GetPageAsync(pageModel, admin, userId);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(long id)
        {
            await _orderService.DeleteAsync(id);
        }

        [HttpPost("buy")]
        [Authorize]
        public async Task<long> BuyAsync(OrderModel orderModel)
        {
            return await _orderService.BuyAsync(orderModel);
        }
    }
}