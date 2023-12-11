using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Domain.Interfaces.Services;
using CustomerManagement.Domain.Services;
using CustomerManagement.Web.Clients.ViaCep;

namespace CustomerManagement.Web.DependencyInjections
{
    public static class ModuleDependency
    {
        public static void ResolveWebDependencies(this IServiceCollection services)
        {
            services.AddScoped<IViaCepClient, ViaCepClient>();
        }
    }
}
