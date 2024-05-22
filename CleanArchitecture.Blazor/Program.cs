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
            var builder = WebApplication.CreateBuilder(args);

            //1- Config services to the container.
            //====================================

            builder.Services.AddBlazorServices(builder.Configuration);

            //2- Build Web Application using Previous builder (that hold settings and services)
            //=================================================================================

            var app = builder.Build();

            //3- Configure the HTTP request pipeline. (Add Middlewares built-in & custome midlewares)
            //=======================================================================================

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
               .AddInteractiveServerRenderMode(); //Enable Interactive Server Render Mode
               

            //4-Start Application
            //===================
            app.Run();
        }
    }
}
