using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent Permissions
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class AppPermission<Tkey> where Tkey : IEquatable<Tkey>
    {
        public Tkey Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<AppUserPermission> UserPermissions { get; set; }
    }
}
