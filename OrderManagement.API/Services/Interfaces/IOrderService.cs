using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using System.Threading.Tasks;

namespace OrderManagement.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task Create(CreateOrderRequest reuest);
        Task Update(UpdateOrderRequest reuest);
        Task Delete(int id);
        Task<GetOrderResponse> GetById(int id);
    }
}
