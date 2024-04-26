using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent User Logins
    /// </summary>
    public class AppUserLogin<TKey>:IdentityUserLogin<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Users Logins Table
        
    }
}
