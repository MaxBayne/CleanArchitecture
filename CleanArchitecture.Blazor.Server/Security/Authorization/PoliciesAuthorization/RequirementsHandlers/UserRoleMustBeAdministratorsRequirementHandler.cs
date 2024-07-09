using CleanArchitecture.Blazor.Server.Security.Authorization.PoliciesAuthorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Blazor.Server.Security.Authorization.PoliciesAuthorization.RequirementsHandlers
{
    public class UserRoleMustBeAdministratorsRequirementHandler : AuthorizationHandler<UserRoleMustBeAdministratorsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleMustBeAdministratorsRequirement requirement)
        {
            if (context.User.IsInRole("Administrators"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
