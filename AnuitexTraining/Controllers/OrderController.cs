using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<OrderModel>> GetPageAsync(OrderModel filter, int page, int pageSize)
        {
            var orderModelPageModel = new OrderModelPageModel
            {
                Filter = filter,
                Page = page,
                PageSize = pageSize,
                Admin = User.FindFirst(ClaimTypes.Role).Value == "Admin",
                UserId = long.Parse(User.FindFirst("Id").Value)
            };
            return await _orderService.GetPageAsync(orderModelPageModel);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task AddAsync(OrderModel order)
        {
            await _orderService.AddAsync(order, long.Parse(User.FindFirst("Id").Value));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(long id)
        {
            await _orderService.DeleteAsync(id);
        }

        [HttpGet("buy/{id}")]
        [Authorize]
        public async Task BuyAsync(long id, string transactionToken)
        {
            await _orderService.BuyAsync(id, transactionToken);
        }
    }
}