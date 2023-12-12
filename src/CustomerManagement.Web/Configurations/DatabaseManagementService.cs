using CustomerManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Web.Configurations
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CustomerManagementContext>().Database.Migrate();
            }
        }
    }
}
