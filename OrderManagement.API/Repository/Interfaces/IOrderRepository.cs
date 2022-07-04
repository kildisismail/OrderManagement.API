using OrderManagement.API.Entities;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task Add(Order entity);

        Task Update(Order entity);

        Task Delete(int id);

        Task<Order> GetById(int id);
    }
}
