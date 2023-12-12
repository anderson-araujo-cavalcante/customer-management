using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Extensions;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Domain.Interfaces.Services;
using System.Linq.Expressions;
using System.Reflection.Metadata;

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

        public async Task<IEnumerable<Customer>> GetAllAsync(string name, string email)
        {
            Expression<Func<Customer, bool>> predicate = (x) => x.Id > 0;

            if (!string.IsNullOrWhiteSpace(name)) predicate = predicate.And(x => x.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(email)) predicate = predicate.And(x => x.Email.Contains(email));

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
