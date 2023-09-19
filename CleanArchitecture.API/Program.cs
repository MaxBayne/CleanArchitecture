using CleanArchitecture.Application.ADependencyInjection;
using CleanArchitecture.Infrastructure.ADependencyInjection;
using CleanArchitecture.Persistence.ADependencyInjection;


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
            builder.Services.ConfigurePersistanceServices(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(o =>{ o.AddPolicy("CorsPolicy",corsPolicyBuilder=>corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            // Build Application
            var app = builder.Build();

            // Configure the HTTP request pipeline. (Middleware)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            //Start Application
            app.Run();
        }
    }
}