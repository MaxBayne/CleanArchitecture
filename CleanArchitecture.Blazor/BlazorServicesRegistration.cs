using System.Reflection;
using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Blazor.Clients.Implements;
using CleanArchitecture.Blazor.ViewModels.Game;

namespace CleanArchitecture.Blazor
{
    public static class BlazorServicesRegistration
    {
        public static IServiceCollection AddBlazorServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            //Blazor Render Modes
            //--------------------
            //1- Static Server Side Render : its Default Render Mode For Blazor Components (Mean Blazor Make Request to Server and Wait For Response)
            //2- Interactive Server Side Render : mean browser open websocket between browser and server and any reaction made for UI will be send to Server Via WebSocket and Take Response
            //3- Client Side Render : mean Dot Net Runtime and App Bundles will be Downloaded and Cached inside Browser and Render will be made via Web Browser by Web Assembly , its perfect for offline apps
            //4- Automatic Render : mean will get benefits from interactive server render and Client Side Render mean first time will get component from interactive server render and on each sub request from component will be render via Client Render using Web Assembly


            // Add services (Dependency Injection) to the container.
            services.AddRazorComponents()
                            .AddInteractiveServerComponents();//enable interactive Server Side Render (Web Socket)
                            

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
