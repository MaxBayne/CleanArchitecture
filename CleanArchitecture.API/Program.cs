using CleanArchitecture.Application;
using CleanArchitecture.Identity;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;
using CleanArchitecture.API.Infrastructure;
using CleanArchitecture.API;
using CleanArchitecture.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

//1- Config services to the container.
//====================================
builder.Services.AddApplicationServices()
                .AddInfrastructureServices(builder.Configuration)
                .AddPersistenceServices(builder.Configuration)
                .AddIdentityServices(builder.Configuration)
                .AddApiServices();


//2- Build Web Application using Previous builder (that hold settings and services)
//=================================================================================

var app = builder.Build();


//3- Configure the HTTP request pipeline. (Add Middlewares built-in & custome midlewares)
//=======================================================================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

//Configure Security
app.UseAuthentication();
app.UseAuthorization();

//Set Custom Middleware
app.UseMiddleware<ProfilingMiddleware>();

//Map Endpoints
app.MapControllers(); //Endpoints over Controller classes
app.MapEndpoints(); //Endpoints inside files

//4-Start Application
//===================
app.Run();