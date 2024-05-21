using CleanArchitecture.Identity.Contexts;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static void ExecuteDbMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //Get Required Services From Dependency Injection Container
                var loggerService = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                var identityDbContextService = serviceScope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>();
                var applicationDbContextService = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                try
                {
                    loggerService.LogInformation("------------------------");
                    loggerService.LogInformation("Start Database Migration");
                    loggerService.LogInformation("------------------------");

                    identityDbContextService.Database.Migrate();
                    applicationDbContextService.Database.Migrate();

                    loggerService.LogInformation("------------------------");
                    loggerService.LogInformation("Finish Database Migration");
                    loggerService.LogInformation("------------------------");
                }
                catch (Exception ex)
                {
                    loggerService.LogError(ex.Message);
                }
                
            }
        }
    }
}
