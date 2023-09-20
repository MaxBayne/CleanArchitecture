using MediatR;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.API.ADependencyInjection
{
    public static class ApiServicesRegistration
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            //Register Services inside Dependency Injection System

            services.AddTransient<IMediator, Mediator>();

            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "CleanArchitecture.Api", Version = "V1" });
            });
            
            services.AddCors(o => { o.AddPolicy("CorsPolicy", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });


            return services;
        }
    }
}
