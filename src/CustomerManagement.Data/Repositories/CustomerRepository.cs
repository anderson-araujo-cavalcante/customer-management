using CustomerManagement.Data.Context;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces.Repositories;

namespace CustomerManagement.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
