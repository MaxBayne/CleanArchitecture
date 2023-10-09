using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Persistence.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register DbContexts inside Dependency Injection System as Scoped LifeTime mean only one connection for every client
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));
            });


            //Register Repositories inside Dependency Injection System as Scoped
            services.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
