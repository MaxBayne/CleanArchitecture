using CleanArchitecture.Blazor;
using CleanArchitecture.Blazor.Views;
using CleanArchitecture.Blazor.Client.Views.Pages;



var builder = WebApplication.CreateBuilder(args);

//1- Add services to the container (Dependency Injection)
//=======================================================

builder.Services.AddBlazorServices(builder.Configuration);

//2- Build Web Application using Previous builder (that hold settings and services)
//=================================================================================

var app = builder.Build();

//3- Configure the HTTP request pipeline. (Add Middlewares built-in & custome midlewares)
//=======================================================================================
if (app.Environment.IsDevelopment())
{
    //On Development Stage

    app.UseWebAssemblyDebugging();
}
else
{
    //On Production Stage
    //
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

//4-Start Application
//===================
app.Run();
