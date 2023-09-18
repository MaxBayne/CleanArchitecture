using CleanArchitecture.Application.Persistence.Abstract;
using CleanArchitecture.Application.Persistence.Repositories;
using CleanArchitecture.Persistence.Bases;
using CleanArchitecture.Persistence.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Persistence.ADependencyInjection
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register DbContexts inside Dependency Injection System as Scoped
            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")),ServiceLifetime.Scoped);


            //Register Repositories inside Dependency Injection System as Scoped
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
