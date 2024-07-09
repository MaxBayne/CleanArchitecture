using CleanArchitecture.API.Security.Authorization.PermissionsAuthorization;
using MediatR;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.API
{
    public static class ServicesRegistrationForApi
    {
        /// <summary>
        /// Register General Services For Api inside Service Collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            services.AddControllers(mvcOptions =>
            {
                //Register All Filters that will be Executed with every Action Method

                //mvcOptions.Filters.Add<LogActivityFilter>();
                mvcOptions.Filters.Add<AuthorizePermissionFilter>();

            })
                    .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null; //make api serialize objects without change camel case of names
            });

            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = "JWT Authorization Token , Put in Header Request [Authorization]=Bearer Token like => Bearer 1245787"
                });

                swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.ApiKey,
                            Scheme = "oautho2",
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }
                        ,
                        new List<string>()
                    }

                });

                swaggerOptions.SwaggerDoc("v1", new OpenApiInfo() { Title = "CleanArchitecture.Api", Version = "V1" });
            });
            
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("CorsPolicy", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddTransient<IMediator, Mediator>();

            return services;
        }
    }
}
