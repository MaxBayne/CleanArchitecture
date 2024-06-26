﻿using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent User Roles (Relation Between Users and Roles where Every User Can be retlated with more Roles)
    /// </summary>
    public class AppUserRole<TKey>:IdentityUserRole<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Users Roles Table
        
        public AppUser<Guid> User { get; set; }

        public AppRole<Guid> Role { get; set; }
    }
}
