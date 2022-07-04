using OrderManagement.API.Entities;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Interfaces
{
    public interface ICustomerRepository 
    {
        Task Add(Customer entity);

        Task Update(Customer entity);

        Task Delete(int id);

        Task<Customer> GetById(int id);
    }
}
