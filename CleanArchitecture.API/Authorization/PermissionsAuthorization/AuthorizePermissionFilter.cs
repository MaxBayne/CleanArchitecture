using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Models.Identity.Authorization;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CleanArchitecture.API.Authorization.PermissionsAuthorization
{
    public class AuthorizePermissionFilter : IAsyncAuthorizationFilter
    {
        private readonly ILogger<AuthorizePermissionFilter> _logger;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizePermissionFilter(ILogger<AuthorizePermissionFilter> logger, IAuthorizationService authorizationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //check if the current Action applied authorizePermissionAttribute over it or not
            var authorizePermissionAttribute = context.ActionDescriptor.EndpointMetadata.FirstOrDefault(c => c is AuthorizePermissionAttribute) as AuthorizePermissionAttribute;

            if (authorizePermissionAttribute != null)
            {
                //Check if current user is Authenticated mean logged in
                if (context.HttpContext.User.Identity?.IsAuthenticated == false)
                {
                    //User Not Authenticated mean not logged in
                    //---------------------------------

                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    //User Authenticated mean Logged in
                    //---------------------------------

                    //Check if current user has that permission applied over the action or not

                    var userClaims = context.HttpContext.User.Identity as ClaimsIdentity;

                    if (userClaims != null)
                    {
                        var nameIdentifierClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
                        var userId = Guid.Parse(nameIdentifierClaim!.Value);
                        var permissionType = authorizePermissionAttribute.PermissionType;

                        var hasPermission = await _authorizationService.HasPermission(userId, permissionType);

                        if (hasPermission == false)
                        {
                            //User Not has Permission
                            context.Result = new ForbidResult();
                        }
                    }

                }

            }


        }
    }
}
