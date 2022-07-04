using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Entities;
using OrderManagement.API.Repository.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task Add(Customer entity)
        {
            _context.Attach<Customer>(entity);
            await _context.Set<Customer>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<Customer>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Active);
            entity.Active = false;
            entity.UpdatedAt = System.DateTime.Now;

            _context.Set<Customer>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Set<Customer>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Active);
        }

        public async Task Update(Customer entity)
        {
            var oldItem = await _context.Set<Customer>()
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
