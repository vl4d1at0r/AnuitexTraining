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
        [Authorize(Roles = "Admin")]
        public async Task<PageDataModel<OrderModel>> GetPageAsync(PageModel<OrderModel> pageModel)
        {
            long userId = long.Parse(User.FindFirst("Id").Value);
            return await _orderService.GetPageAsync(pageModel, true, userId);
        }

        [HttpPost("getUserPage")]
        [Authorize]
        public async Task<PageDataModel<OrderModel>> GetUserPageAsync(PageModel<OrderModel> pageModel)
        {
            long userId = long.Parse(User.FindFirst("Id").Value);
            return await _orderService.GetPageAsync(pageModel, false, userId);
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

        [HttpGet("buyExisting")]
        [Authorize]
        public async Task<long> BuyExistingAsync(long id, string token)
        {
            return await _orderService.BuyExistingAsync(id, token);
        }
    }
}