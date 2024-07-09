using CleanArchitecture.API.Security.Authorization.PoliciesAuthorization.Requirements;
using CleanArchitecture.API.Security.Authorization.PoliciesAuthorization.RequirementsHandlers;
using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Common.Settings;
using CleanArchitecture.Identity.Contexts;
using CleanArchitecture.Identity.Entities;
using CleanArchitecture.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IAuthorizationService = CleanArchitecture.Application.Interfaces.Identity.IAuthorizationService;

namespace CleanArchitecture.API
{
    public static class ServicesRegistrationForSecurity
    {
        /// <summary>
        /// Register Security Services like Identity , Authentication and Authorization
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            //Register Configuration Mapped Classes inside Services , use IOptions<JwtSettings> inside Constructor to resolve the class instance
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            //Config Identity System ------------------------------------------------------------------

            var identityConnectionString = configuration.GetConnectionString("IdentityConnectionString");


            //Register DbContexts inside Dependency Injection System as Scoped Lifetime
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(identityConnectionString, sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName));
            });

            //Register Identity inside Dependency Injection System
            services.AddIdentity<AppUser<Guid>, AppRole<Guid>>()
                    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                    .AddDefaultTokenProviders();


            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();


            //Config Authentications ------------------------------------------------------------------

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


            //Config Authorizations ------------------------------------------------------------------

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
