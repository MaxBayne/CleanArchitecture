using CleanArchitecture.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Identity.ADependencyInjection
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register DbContexts inside Dependency Injection System as Scoped
            services.AddDbContext<ApplicationIdentityDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString")),ServiceLifetime.Scoped);


            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
