using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent User Permission (Relation Between Users and Permission where Every User Can be retlated with more Permission)
    /// </summary>
    public class ApplicationUserPermission
    {
     
        public Guid UserId { get; set; }
        public ApplicationUser<Guid> User { get; set; }


        public int PermissionId { get; set; }
        public ApplicationPermission<int> Permission { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}
