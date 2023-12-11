using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Data.Context
{
    public class CustomerManagementContext : DbContext
    {
        public CustomerManagementContext(DbContextOptions<CustomerManagementContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}
