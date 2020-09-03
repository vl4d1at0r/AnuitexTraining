using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnuitexTraining.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("getPage")]
        [Authorize]
        public async Task<IEnumerable<OrderModel>> GetPageAsync(OrderModel filter, int page, int pageSize)
        {
            return await _orderService.GetPageAsync(filter, page, pageSize, User.FindFirst(ClaimTypes.Role).Value == "Admin", long.Parse(User.FindFirst("Id").Value));
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
