using OrderManagement.API.Entities;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task Add(Product entity);

        Task Update(Product entity);

        Task Delete(int id);

        Task<Product> GetById(int id);
    }
}
