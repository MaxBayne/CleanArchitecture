using CleanArchitecture.API.ADependencyInjection;
using CleanArchitecture.Application.ADependencyInjection;
using CleanArchitecture.Infrastructure.ADependencyInjection;
using CleanArchitecture.Persistence.ADependencyInjection;
using CleanArchitecture.Identity.ADependencyInjection;


namespace CleanArchitecture.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Config services to the container.
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigurePersistenceServices(builder.Configuration);
            builder.Services.ConfigureIdentityServices(builder.Configuration);
            builder.Services.ConfigureApiServices();

            // Build Application
            var app = builder.Build();

            // Configure the HTTP request pipeline. (Middleware)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            //Configure Security
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();


            //Start Application
            app.Run();
        }
    }
}