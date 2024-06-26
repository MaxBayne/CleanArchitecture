﻿using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent Roles
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class AppRole<Tkey> : IdentityRole<Tkey> where Tkey : IEquatable<Tkey>
    {
        //Put Here any Aditionals Fields that will be stored inside Roles Table

        public ICollection<AppUserRole<Guid>> UserRoles { get; set; }
    }
}
