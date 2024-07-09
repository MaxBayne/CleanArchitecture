using CleanArchitecture.API.Security.Authorization.PoliciesAuthorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.API.Security.Authorization.PoliciesAuthorization.RequirementsHandlers
{
    public class UserRoleMustBeSupervisorssRequirementHandler : AuthorizationHandler<UserRoleMustBeSupervisorssRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleMustBeSupervisorssRequirement requirement)
        {
            if (context.User.IsInRole("Supervisorss"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
