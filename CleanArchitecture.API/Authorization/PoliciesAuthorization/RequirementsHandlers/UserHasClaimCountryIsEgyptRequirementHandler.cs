﻿using CleanArchitecture.API.Authorization.PoliciesAuthorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CleanArchitecture.API.Authorization.PoliciesAuthorization.RequirementsHandlers
{
    public class UserHasClaimCountryIsEgyptRequirementHandler : AuthorizationHandler<UserHasClaimCountryIsEgyptRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserHasClaimCountryIsEgyptRequirement requirement)
        {
            if (context.User.HasClaim(ClaimTypes.Country, "Egypt"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
