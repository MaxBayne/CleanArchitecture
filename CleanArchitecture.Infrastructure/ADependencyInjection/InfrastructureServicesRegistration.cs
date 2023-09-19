using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.ADependencyInjection
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<IEmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSenderService, EmailSenderService>();

            return services;
        }
    }
}
