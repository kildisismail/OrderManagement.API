using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetProductResponse>> Search([FromQuery] string searchText)
        {
            return await _productService.Search(searchText);
        }

        [HttpGet]
        public async Task<GetProductResponse> Get([FromQuery] int id)
        {
            return await _productService.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] CreateProductRequest request)
        {
            await _productService.CreateProductWithIndexing(request);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateProductRequest request)
        {           
            await _productService.UpdateProductWithIndexing(request);
        }

        [HttpDelete]
        public async Task Delete( [FromQuery] int id)
        {
            await _productService.DeleteProductWithIndexing(id);
        }
    }
}
