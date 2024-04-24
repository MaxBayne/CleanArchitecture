using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UsersClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("UsersClaims", "Identity");

            //Config Primary Key

            //Config Columns


            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------

        }

        #endregion
    }
}
