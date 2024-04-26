using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent Role Claims
    /// </summary>
    public class AppRoleClaim<TKey>:IdentityRoleClaim<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Roles Claims Table
        
    }
}
