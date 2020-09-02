using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
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
        public async Task<IEnumerable<OrderModel>> GetPageAsync(OrderModel filter, int page, int pageSize)
        {
            return await _orderService.GetPageAsync(filter, page, pageSize);
        }

        [HttpPost("add")]
        public async Task AddAsync(OrderModel order)
        {
            await _orderService.AddAsync(order);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteAsync(long id)
        {
            await _orderService.DeleteAsync(id);
        }

        [HttpGet("buy/{id}")]
        public async Task BuyAsync(long id, string transactionToken)
        {
            await _orderService.BuyAsync(id, transactionToken);
        }
        // TODO: Add all order service methods usings in controller
    }
}
