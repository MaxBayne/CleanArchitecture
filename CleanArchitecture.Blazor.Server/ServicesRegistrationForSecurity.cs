using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using CleanArchitecture.Identity.Contexts;
using CleanArchitecture.Identity.Entities;
using CleanArchitecture.Identity.Services;

using IAuthorizationService = CleanArchitecture.Application.Interfaces.Identity.IAuthorizationService;
using IAuthenticationService = CleanArchitecture.Application.Interfaces.Identity.IAuthenticationService;
using AuthenticationService = CleanArchitecture.Identity.Services.AuthenticationService;

using Microsoft.AspNetCore.Components.Authorization;
using CleanArchitecture.Blazor.Server.Security.Account;
using CleanArchitecture.Blazor.Server.Security.Authorization.PoliciesAuthorization.Requirements;
using CleanArchitecture.Blazor.Server.Security.Authorization.PoliciesAuthorization.RequirementsHandlers;

namespace CleanArchitecture.Blazor.Server;

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

        services.AddSingleton<IEmailSender<AppUser<Guid>>, IdentityNoOpEmailSender>();
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IAuthorizationService, AuthorizationService>();
        

        //Config Identity System ------------------------------------------------------------------

        var identityConnectionString = configuration.GetConnectionString("IdentityConnectionString");
        

        //Register DbContexts inside Dependency Injection System as Scoped Lifetime
        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseSqlServer(identityConnectionString, sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName));
        });

        //Register Identity inside Dependency Injection System
        services.AddIdentityCore<AppUser<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();


        //Config Authentications ------------------------------------------------------------------

        #region Config Basic Authentication

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies();

        //services.AddAuthentication("Basic")
        //        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

        services.AddCascadingAuthenticationState();

        #endregion

        #region Config JWT Bearer Authentication

        //var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

        //services.AddAuthentication(configureOptions =>
        //{
        //    configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})
        //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        //{
        //    //options.SaveToken = true;//where will be save the token inside HttpContext 
        //    options.TokenValidationParameters = new TokenValidationParameters() //How To Validate the Token inside Request
        //    {
        //        //Validate Issuer Name inside Token with the Value Stored inside AppSettings
        //        ValidateIssuer = true,
        //        ValidIssuer = jwtSettings?.Issuer,

        //        //Validate Audience Name inside Token with the Value Stored inside AppSettings
        //        ValidateAudience = true,
        //        ValidAudience = jwtSettings?.Audience,

        //        //Validate Issuer Signing Key that Used To Sign the Token
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.IssuerSigningKey!)),

        //        ValidateLifetime = true,
        //        ClockSkew = TimeSpan.Zero,

        //    };
        //});

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
