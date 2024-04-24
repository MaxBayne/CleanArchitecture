using CleanArchitecture.Identity.Configurations;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser<Guid>,ApplicationRole<Guid>,Guid>
    {
        #region Constructors
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }
        #endregion

        #region Configuration
        // Called When Database being Generated using Migration , can use it to config tables with rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsersConfiguration());

            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionsConfiguration());

            modelBuilder.ApplyConfiguration(new UsersClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersTokensConfiguration());
            modelBuilder.ApplyConfiguration(new UsersLoginsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersRolesConfiguration());
            modelBuilder.ApplyConfiguration(new UsersPermissionsConfiguration());

            modelBuilder.ApplyConfiguration(new RolesClaimsConfiguration());


        }
        #endregion

        #region DbSets

        #endregion
    }
}
