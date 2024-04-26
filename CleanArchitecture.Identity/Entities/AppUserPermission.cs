using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent User Permission (Relation Between Users and Permission where Every User Can be retlated with more Permission)
    /// </summary>
    public class AppUserPermission
    {
     
        public Guid UserId { get; set; }
        public AppUser<Guid> User { get; set; }


        public int PermissionId { get; set; }
        public AppPermission<int> Permission { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}
