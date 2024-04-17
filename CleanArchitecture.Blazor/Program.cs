using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Blazor.Clients.Implements;
using CleanArchitecture.Blazor.Components;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;
using CleanArchitecture.Blazor.ViewModels.Implements.Game;

namespace CleanArchitecture.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services (Dependency Injection) to the container.
            builder.Services.AddRazorComponents();

            //Register Clients
            builder.Services.AddSingleton<IGamesClient,GamesClient>();
            builder.Services.AddSingleton<IGenresClient,GenresClient>();

            //Register ViewModels
            builder.Services.AddScoped<ICreateGameViewModel,CreateGameViewModel>();
            builder.Services.AddScoped<IEditGameViewModel, EditGameViewModel>();
            builder.Services.AddScoped<IDeleteGameViewModel, DeleteGameViewModel>();
            builder.Services.AddScoped<IDetailsGameViewModel, DetailsGameViewModel>();
            builder.Services.AddScoped<IListGameViewModel, ListGameViewModel>();
           


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

            app.MapRazorComponents<App>();

            app.Run();
        }
    }
}
