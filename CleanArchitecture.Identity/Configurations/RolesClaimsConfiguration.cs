using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RolesClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("RolesClaims", "Identity");

            //Config Primary Key

            //Config Columns


            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------

        }

        #endregion
    }
}
