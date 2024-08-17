namespace CleanArchitecture.Blazor.Wasm;

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

        // Config Google Identity Provider
        //================================

        #region Config Google Identity Provider

        services.AddOidcAuthentication(options =>
        {
            configuration.Bind("IdentityProviders.Google", options.ProviderOptions);

            options.ProviderOptions.Authority = configuration.GetValue<string>("IdentityProviders.Google.Authority");
            options.ProviderOptions.ClientId = configuration.GetValue<string>("IdentityProviders.Google.ClientId");
            options.ProviderOptions.DefaultScopes.Add("openid");
            options.ProviderOptions.DefaultScopes.Add("profile");
            options.ProviderOptions.DefaultScopes.Add("email");
        });

        #endregion


        services.AddApiAuthorization();


        return services;
    }
}
