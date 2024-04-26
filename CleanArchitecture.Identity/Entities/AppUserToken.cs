using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent User Tokens , Hold All Tokens For Users
    /// </summary>
    public class AppUserToken<TKey>:IdentityUserToken<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Users Tokens Table
        
    }
}
