using CleanArchitecture.Persistence.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;

namespace CleanArchitecture.Persistence.ADependencyInjection
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register DbContexts inside Dependency Injection System as Scoped LifeTime
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));
            });


            //Register Repositories inside Dependency Injection System as Scoped
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
