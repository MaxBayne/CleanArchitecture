using System.Reflection;
using CleanArchitecture.Blazor.Server.ApiClients.Contracts;
using CleanArchitecture.Blazor.Server.ApiClients.Implements;

using CleanArchitecture.Blazor.Server.Security.Authentication;
using CleanArchitecture.Blazor.Server.Security.Authorization.PoliciesAuthorization.RequirementsHandlers;
using CleanArchitecture.Blazor.Server.ViewModels.Game;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Blazor.Server
{
    public static class ServicesRegistrationForBlazor
    {
        /// <summary>
        /// Register General Services For Blazor Web App inside Services Collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IServiceCollection AddBlazorServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System


            // Add services (Dependency Injection) to the container.
            services.AddRazorComponents()
                            .AddInteractiveServerComponents()       //enable interactive in Server Side (Web Socket)
                            .AddInteractiveWebAssemblyComponents(); //enable interactive in Client Side (Web Assembly)
                            

            //Add Other Services to container
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //Register Http Clients
            services.AddHttpClient<IGamesClient, GamesClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["Api:OnlineStoreApiUrl"] ?? throw new Exception("Missing Setting (Api:OnlineStoreApiUrl) inside appsettings.json"));
            });
            services.AddHttpClient<IGenresClient, GenresClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["Api:OnlineStoreApiUrl"] ?? throw new Exception("Missing Setting (Api:OnlineStoreApiUrl) inside appsettings.json"));
            });

            //Register ViewModels
            services.AddScoped<CreateGameViewModel>();
            services.AddScoped<EditGameViewModel>();
            services.AddScoped<DetailsGameViewModel>();
            services.AddScoped<ListGameViewModel>();

            return services;
        }
    }
}
