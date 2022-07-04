using OrderManagement.API.Entities;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Interfaces
{
    public interface IOrderItemRepository 
    {
        Task Add(OrderItem entity);

        Task Update(OrderItem entity);

        Task Delete(int id);

        Task<OrderItem> GetById(int id);
    }
}
