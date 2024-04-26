using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Identity.Contexts;
using CleanArchitecture.Identity.Entities;
using CleanArchitecture.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            
            var identityConnectionString = configuration.GetConnectionString("IdentityConnectionString");


            //Register DbContexts inside Dependency Injection System as Scoped Lifetime
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(identityConnectionString, sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName));
            });

            //Register Identity inside Dependency Injection System
            services.AddIdentity<AppUser<Guid>, AppRole<Guid>>()
                    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                    .AddDefaultTokenProviders();


            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}
