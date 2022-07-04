using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.API.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateProductWithIndexing(CreateProductRequest product);
        Task UpdateProductWithIndexing(UpdateProductRequest reuest);
        Task DeleteProductWithIndexing(int id);
        Task<GetProductResponse> GetById(int id);
        Task<IEnumerable<GetProductResponse>> Search(string searchData);

    }
}
