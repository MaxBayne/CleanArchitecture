using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UsersTokensConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("UsersTokens", "Identity");

            //Config Primary Key

            //Config Columns


            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------

        }

        #endregion
    }
}
