﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application.AppDependencyInjection
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //Register All AutoMapper Profiles (MappingProfile) inside Dependency Injection System
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Register Mediator Services Configurations inside Dependency Injection System
            //services.AddMediatR();
            

            return services;
        }
    }
}
