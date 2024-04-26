using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent User Claims , claims is just information about user
    /// </summary>
    public class AppUserClaim<TKey>:IdentityUserClaim<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Users Claims Table
        
    }
}
