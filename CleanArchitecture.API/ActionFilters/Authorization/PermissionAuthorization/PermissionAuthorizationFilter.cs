using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.API.ActionFilters.Authorization.PermissionAuthorization
{
    public class PermissionAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly ILogger<PermissionAuthorizationFilter> _logger;

        public PermissionAuthorizationFilter(ILogger<PermissionAuthorizationFilter> logger)
        {
            _logger = logger;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            _logger.LogInformation($"OnAuthorizationAsync => {context.ActionDescriptor.DisplayName}");

            return Task.CompletedTask;

        }
    }
}
