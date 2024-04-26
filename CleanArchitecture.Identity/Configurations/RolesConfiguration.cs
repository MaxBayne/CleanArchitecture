using CleanArchitecture.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<AppRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<AppRole<Guid>> builder)
        {
            //Config Table ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }


        #region Configure

        private void ConfigureTable(EntityTypeBuilder<AppRole<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("Roles", "Identity");

            //Config Primary Key
            
            //Config Columns
            
            //Config Shared


            //Config Navigation
            

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<AppRole<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------
            
            builder.HasData(new List<AppRole<Guid>>()
            {
                new AppRole<Guid>()
                {
                    Id=Guid.Parse("557D96C5-6AB6-40B9-B2A3-47166E861366"),
                    Name="Administrators",
                    NormalizedName="ADMINISTRATORS"
                },
                new AppRole<Guid>()
                {
                    Id=Guid.Parse("447D96C5-6AB6-40B9-B2A3-47166E861366"),
                    Name="Supervisors",
                    NormalizedName="SUPERVISORS"
                },
                new AppRole<Guid>()
                {
                    Id=Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366"),
                    Name="Users",
                    NormalizedName="USERS"
                }
            });
        }

        #endregion

    }
}
