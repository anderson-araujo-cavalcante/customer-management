using AutoMapper;
using CustomerManagement.Web.Profiles;

namespace CustomerManagement.Web.Configurations
{
    public static class AutomapperConfig
    {
        public static IServiceCollection MapperConfig(this IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerProfile>();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            return services;
        }
    }
}
