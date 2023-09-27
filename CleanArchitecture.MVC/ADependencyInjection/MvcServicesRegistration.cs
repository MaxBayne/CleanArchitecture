using System.Reflection;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.Services.Implement;

namespace CleanArchitecture.MVC.ADependencyInjection
{
    public static class MvcServicesRegistration
    {
        public static IServiceCollection ConfigureMvcServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            var apiUrl = configuration.GetSection("api").Value;

            services.AddControllersWithViews();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpClient<IApiClient, ApiClient>(c=>c.BaseAddress=new Uri(apiUrl!));


            services.AddSingleton<ILocalStorageService, LocalStorageService>();
            
            services.AddScoped<IBooksService, BooksService>();

            services.AddTransient<IIdentityService, IdentityService>();



            return services;
        }
    }
}
