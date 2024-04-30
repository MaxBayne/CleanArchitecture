using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Blazor.Clients.Implements;
using CleanArchitecture.Blazor.Components;
using CleanArchitecture.Blazor.ViewModels.Game;

namespace CleanArchitecture.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Blazor Render Modes
            //--------------------
            //1- Static Server Side Render : its Default Render Mode For Blazor Components (Mean Blazor Make Request to Server and Wait For Response)
            //2- Interactive Server Side Render : mean browser open websocket between browser and server and any reaction made for UI will be send to Server Via WebSocket and Take Response
            //3- Client Side Render : mean Dot Net Runtime and App Bundles will be Downloaded and Cached inside Browser and Render will be made via Web Browser by Web Assembly , its perfect for offline apps
            //4- Automatic Render : mean will get benefits from interactive server render and Client Side Render mean first time will get component from interactive server render and on each sub request from component will be render via Client Render using Web Assembly


            var builder = WebApplication.CreateBuilder(args);

            // Add services (Dependency Injection) to the container.
            builder.Services.AddRazorComponents()
                            .AddInteractiveServerComponents()//enable interactive Server Side Render (Web Socket)
                            ;
            

            //Register Clients
            builder.Services.AddSingleton<IGamesClient,GamesClient>();
            builder.Services.AddSingleton<IGenresClient,GenresClient>();

            //Register ViewModels
            builder.Services.AddScoped<CreateGameViewModel>();
            builder.Services.AddScoped<EditGameViewModel>();
            builder.Services.AddScoped<DetailsGameViewModel>();
            builder.Services.AddScoped<ListGameViewModel>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
               .AddInteractiveServerRenderMode() //Enable Interactive Server Render Mode
               ; 

            app.Run();
        }
    }
}
