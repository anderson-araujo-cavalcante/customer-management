using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces.Repositories;

namespace CustomerManagement.Domain.Interfaces.Services
{
    public interface ICustomerService : IRepositoryBase<Customer>
    {
    }
}
