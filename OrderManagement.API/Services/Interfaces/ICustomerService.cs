using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using System.Threading.Tasks;

namespace OrderManagement.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task Create(CreateCustomerRequest reuest);
        Task Update(UpdateCustomerRequest reuest);
        Task Delete(int id);
        Task<GetCustomerResponse> GetById(int id);
    }
}
