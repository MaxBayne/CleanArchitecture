using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UsersLoginsConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("UsersLogins", "Identity");

            //Config Primary Key

            //Config Columns


            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------

        }

        #endregion
    }
}
