using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Services.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<GetCustomerResponse> Get([FromQuery] int id)
        {
            return await _customerService.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] CreateCustomerRequest request)
        {
            await _customerService.Create(request);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateCustomerRequest request)
        {
            await _customerService.Update(request);
        }

        [HttpDelete]
        public async Task Delete([FromQuery] int id)
        {
            await _customerService.Delete(id);
        }
    }
}
