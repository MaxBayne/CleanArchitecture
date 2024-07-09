using System.Reflection;
using CleanArchitecture.Blazor.Wasm.ApiClients.Contracts;
using CleanArchitecture.Blazor.Wasm.ApiClients.Implements;
using CleanArchitecture.Blazor.Wasm.ViewModels.Game;

namespace CleanArchitecture.Blazor.Wasm
{
    public static class BlazorServicesRegistration
    {
        public static IServiceCollection AddBlazorServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System


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

            //Register Authentication (Security)
            //services.AddOptions();
            //services.AddCascadingAuthenticationState();
            services.AddAuthorizationCore();

            return services;
        }
    }
}
