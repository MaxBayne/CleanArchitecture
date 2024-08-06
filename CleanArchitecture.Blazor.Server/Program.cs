using CleanArchitecture.Blazor.Server;
using CleanArchitecture.Blazor.Server.Views;
using CleanArchitecture.Blazor.Client.Views.Pages;



var builder = WebApplication.CreateBuilder(args);

//1- Add services to the container (Dependency Injection)
//=======================================================

builder.Services.AddSecurityServices(builder.Configuration)
                .AddBlazorServices(builder.Configuration);

//2- Build Web Application using Previous builder (that hold settings and services)
//=================================================================================

var app = builder.Build();

//3- Configure the HTTP request pipeline. (Add Middlewares built-in & custome midlewares)
//=======================================================================================
if (app.Environment.IsDevelopment())
{
    //On Development Stage

    app.UseWebAssemblyDebugging();
    //app.UseMigrationsEndPoint();
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


// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

//4-Start Application
//===================
app.Run();
