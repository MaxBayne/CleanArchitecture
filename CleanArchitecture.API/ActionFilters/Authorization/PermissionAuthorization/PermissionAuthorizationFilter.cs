using CleanArchitecture.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.API.ActionFilters.Authorization.PermissionAuthorization
{
    public class PermissionAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly ILogger<PermissionAuthorizationFilter> _logger;
        private readonly IAuthorizationService _authorizationService;

        public PermissionAuthorizationFilter(ILogger<PermissionAuthorizationFilter> logger,IAuthorizationService authorizationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            _logger.LogInformation($"OnAuthorizationAsync => {context.ActionDescriptor.DisplayName}");

            return Task.CompletedTask;

        }
    }
}
