using CustomerManagement.Domain.Interfaces.Services;
using CustomerManagement.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Domain.DependencyInjections
{
    public static class ModuleDependency2
    {
        public static void ResolveDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
