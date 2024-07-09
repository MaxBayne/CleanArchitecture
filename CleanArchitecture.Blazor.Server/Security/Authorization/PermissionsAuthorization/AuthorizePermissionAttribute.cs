using CleanArchitecture.Domain.Enums;
using System.Diagnostics;

namespace CleanArchitecture.Blazor.Server.Security.Authorization.PermissionsAuthorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [DebuggerDisplay("{ToString(),nq}")]
    public class AuthorizePermissionAttribute : Attribute
    {
        public PermissionType PermissionType { get; set; }


        public AuthorizePermissionAttribute(PermissionType permissionType)
        {
            PermissionType = permissionType;
        }

    }
}
