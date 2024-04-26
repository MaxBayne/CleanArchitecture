using CleanArchitecture.Identity.Configurations;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<AppUser<Guid>,
                                                                  AppRole<Guid>,
                                                                  Guid,
                                                                  AppUserClaim<Guid>,
                                                                  AppUserRole<Guid>,
                                                                  AppUserLogin<Guid>,
                                                                  AppRoleClaim<Guid>,
                                                                  AppUserToken<Guid>>
    {
        #region Constructors
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }
        #endregion

        #region Configuration
        // Called When Database being Generated using Migration , can use it to config tables with rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationIdentityDbContext).Assembly);

        }
        #endregion

        #region DbSets

        #endregion
    }
}
