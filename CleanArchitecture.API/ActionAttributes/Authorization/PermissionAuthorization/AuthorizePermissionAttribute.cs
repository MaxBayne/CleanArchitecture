using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.API.ActionAttributes.Authorization.PermissionAuthorization
{
    /// <summary>
    /// Set Method Allowed Only For Permission
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =true)]
    public class AuthorizePermissionAttribute: Attribute
    {
        public AuthorizePermissionAttribute(PermissionType permissionType)
        {
            PermissionType = permissionType;
        }

        public PermissionType PermissionType { get; }
    }
}
