using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Persistence.Abstracts;
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
            //Register DbContexts inside Dependency Injection System as Scoped LifeTime mean only one connection for every Request
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));
            });

            //Register Unit of Work inside Dependency Injection as Transient
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Register Repositories inside Dependency Injection System as Transient
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            
            return services;
        }
    }
}
