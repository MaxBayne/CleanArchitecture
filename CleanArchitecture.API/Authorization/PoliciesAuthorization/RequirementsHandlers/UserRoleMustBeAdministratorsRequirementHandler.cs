using CleanArchitecture.API.Authorization.PoliciesAuthorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.API.Authorization.PoliciesAuthorization.RequirementsHandlers
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
