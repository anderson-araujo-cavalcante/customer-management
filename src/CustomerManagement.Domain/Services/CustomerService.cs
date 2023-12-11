using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace CustomerManagement.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task AddAsync(Customer obj)
        {
            await _customerRepository.AddAsync(obj);
        }       

        public async Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _customerRepository.GetAllAsync(predicate);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _customerRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await _customerRepository.UpdateAsync(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
