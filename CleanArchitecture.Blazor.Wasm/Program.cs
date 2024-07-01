using CleanArchitecture.Blazor.Wasm;
using CleanArchitecture.Blazor.Wasm.Views;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//1- Add appSettings.json File inside Configuration
//=================================================
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


//2- Add services to the container (Dependency Injection)
//=======================================================
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazorServices(builder.Configuration);


//3- Build Web Application using Previous builder (that hold settings and services)
//=================================================================================
await builder.Build().RunAsync();
