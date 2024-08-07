﻿using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.AspNetCore.Shared;

namespace CleanArchitecture.API.Security.Authorization.PermissionsAuthorization
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
