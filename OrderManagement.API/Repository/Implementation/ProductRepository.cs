using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Entities;
using OrderManagement.API.Repository.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task Add(Product entity)
        {
            _context.Attach(entity);
            await _context.Set<Product>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<Product>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Active);
            entity.Active = false;
            entity.UpdatedAt = System.DateTime.Now;

            _context.Set<Product>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Set<Product>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Active);
        }

        public async Task Update(Product entity)
        {
            var oldItem = await _context.Set<Product>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == entity.Id && x.Active);

            entity.UpdatedAt = System.DateTime.Now;
            entity.CreatedAt = oldItem.CreatedAt;
            entity.Active = oldItem.Active;
            entity.Id = oldItem.Id;

            _context.Entry(oldItem).State = EntityState.Modified;
            _context.Entry(oldItem).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
