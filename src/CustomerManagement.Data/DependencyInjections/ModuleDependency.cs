using CustomerManagement.Data.Repositories;
using CustomerManagement.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Data.DependencyInjections
{
    public static class ModuleDependency3
    {
        public static void ResolveDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
