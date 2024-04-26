using CleanArchitecture.Domain.Aggregates;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class PermissionsConfiguration : IEntityTypeConfiguration<AppPermission<int>>
    {
        public void Configure(EntityTypeBuilder<AppPermission<int>> builder)
        {
            //Config Table Schema ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<AppPermission<int>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("Permissions", "Identity");

            //Config Primary Key
            builder.HasKey(u => u.Id);
            builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            //Config Columns
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(250);

            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<AppPermission<int>> builder)
        {
            //Seeding Data ------------------------------------------------
            builder.HasData(new List<AppPermission<int>>()
            {
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanInsert,
                    Name="CanInsert",
                    Description="Can Insert Data"
                },
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanUpdate,
                    Name="CanUpdate",
                    Description="Can Update Data"
                },
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanDelete,
                    Name="CanDelete",
                    Description="Can Delete Data"
                },
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanPrint,
                    Name="CanPrint",
                    Description="Can Print Data"
                },
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanImport,
                    Name="CanImport",
                    Description="Can Import Data"
                },
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanExport,
                    Name="CanExport",
                    Description="Can Export Data"
                },
                new AppPermission<int>()
                {
                    Id=(int)PermissionType.CanView,
                    Name="CanView",
                    Description="Can View Data"
                },

            });
        }

        #endregion
    }
}
