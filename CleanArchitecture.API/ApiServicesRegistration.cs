using CleanArchitecture.API.Authentication.BasicAuthentication;
using CleanArchitecture.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CleanArchitecture.API
{
    public static class ApiServicesRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));


            services.AddControllers().AddJsonOptions(jsonOptions =>
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


            //Config API Security (Authentications)

            #region Config Basic Authentication

            services.AddAuthentication("Basic")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

            #endregion

            #region Config Bearer Token Authentication

            #endregion

            #region Config JWT Bearer Authentication

            //services.AddAuthentication(authenticationOptions =>
            //{
            //    //authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //Bearer Scheme
            //    //authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(jwtBearerOptions =>
            //{
            //    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero,
            //        ValidIssuer = configuration["JwtSettings:Issuer"],
            //        ValidAudience = configuration["JwtSettings:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!))
            //    };
            //});

            #endregion


            return services;
        }
    }
}
