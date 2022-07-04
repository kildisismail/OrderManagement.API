using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderManagement.API.Entities;

namespace OrderManagement.API.Repository
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
