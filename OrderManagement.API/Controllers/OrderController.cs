using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Services.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<GetOrderResponse> Get([FromQuery]int id)
        {
           return await _orderService.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] CreateOrderRequest request)
        {
            await _orderService.Create(request);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateOrderRequest request)
        {
            await _orderService.Update(request);
        }

        [HttpDelete]
        public async Task Delete([FromQuery] int id)
        {
            await _orderService.Delete(id);
        }
    }
}
