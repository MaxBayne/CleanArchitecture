using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent Users
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class AppUser<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Users Table
        
        
        public ICollection<AppUserPermission> UserPermissions { get; set; }

        public ICollection<AppUserRole<Guid>> UserRoles { get; set; }
    }

}
