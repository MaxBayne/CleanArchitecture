using CleanArchitecture.API.Authorization.PermissionsAuthorization;
using CleanArchitecture.API.Authorization.PoliciesAuthorization.Requirements;
using CleanArchitecture.API.Authorization.PoliciesAuthorization.RequirementsHandlers;
using CleanArchitecture.Common.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.API
{
    public static class ApiServicesRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            //Register Configuration Mapped Classes inside Services , use IOptions<JwtSettings> inside Constructor to resolve the class instance
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));



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


            //Config API Security (Authentications)

            #region Config Basic Authentication

            //services.AddAuthentication("Basic")
            //        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

            #endregion

            #region Config JWT Bearer Authentication

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

            services.AddAuthentication(configureOptions =>
            {
                configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                //options.SaveToken = true;//where will be save the token inside HttpContext 
                options.TokenValidationParameters = new TokenValidationParameters() //How To Validate the Token inside Request
                {
                    //Validate Issuer Name inside Token with the Value Stored inside AppSettings
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings?.Issuer,

                    //Validate Audience Name inside Token with the Value Stored inside AppSettings
                    ValidateAudience = true,
                    ValidAudience = jwtSettings?.Audience,

                    //Validate Issuer Signing Key that Used To Sign the Token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.IssuerSigningKey!)),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                };
            });

            #endregion


            //Config API Security (Authorizations)

            #region Config Permission Based Authorization
            
            //Using ActionFilters and Action Attributes

            #endregion

            #region Config Role Based Authorization
            
            //Not Need Configs

            #endregion

            #region Config Policy Based Authorization

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminsOnlyPolicy", policyBuilder =>
                {

                    //mean this policy required user has claim type with claim data
                    //policyBuilder.RequireClaim(ClaimTypes.Role, "Administrators");

                    //mean this policy to be success it required user is in role called administrators
                    //policyBuilder.RequireRole("Administrators");

                    //mean this policy to be success it required user is authenticated
                    //policyBuilder.RequireAuthenticatedUser(); 

                    //mean this policy to be success it required user name is admin
                    //policyBuilder.RequireUserName("admin");

                    //mean check policy pass custom logic inside requirement
                    policyBuilder.AddRequirements(new UserRoleMustBeAdministratorsRequirement());
                });

                options.AddPolicy("AdminsFromEgyptPolicy", policyBuilder =>
                {
                    //to be policy success , all below requirements must be succeded
                    policyBuilder.AddRequirements(new UserRoleMustBeAdministratorsRequirement());
                    policyBuilder.AddRequirements(new UserHasClaimCountryIsEgyptRequirement());
                });
            });

            //Register Authorization Handlers inside Dependency Services
            services.AddSingleton<IAuthorizationHandler, UserHasClaimCountryIsEgyptRequirementHandler>();
            services.AddSingleton<IAuthorizationHandler, UserRoleMustBeAdministratorsRequirementHandler>();
            services.AddSingleton<IAuthorizationHandler, UserRoleMustBeSupervisorssRequirementHandler>();

            #endregion

            return services;
        }
    }
}
