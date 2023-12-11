using CustomerManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Web.Configurations
{
    public static class ConnectionConfig
    {
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
            builder.Services.AddDbContext<CustomerManagementContext>(
            options => options.UseSqlServer(connectionString));

            return builder;
        }
    }
}
