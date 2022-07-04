using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Entities;
using OrderManagement.API.Repository.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task Add(Order entity)
        {
            _context.Attach<Order>(entity);
            await _context.Set<Order>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<Order>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Active);
            entity.Active = false;
            entity.UpdatedAt = System.DateTime.Now;

            _context.Set<Order>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Set<Order>()
                .Include(x=>x.Customer)
                .Include(x=>x.OrderItems)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Active);
        }

        public async Task Update(Order entity)
        {
            var oldItem = await _context.Set<Order>()
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
