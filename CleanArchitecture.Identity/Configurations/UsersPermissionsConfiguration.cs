using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UsersPermissionsConfiguration : IEntityTypeConfiguration<ApplicationUserPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserPermission> builder)
        {
            //Config Table Schema ------------------------------------------------
            ConfigureUserPermissionsTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsUserPermissionsTable(builder);
        }

        #region Configure

        private void ConfigureUserPermissionsTable(EntityTypeBuilder<ApplicationUserPermission> userPermissionBuilder)
        {
            //Config Table Schema ------------------------------------------------
            userPermissionBuilder.ToTable("UsersPermissions", "Identity");

            //Config Primary Key (Composite Key)
            userPermissionBuilder.HasKey(u => new { u.UserId, u.PermissionId });


            //Config Columns
            userPermissionBuilder.Property(p => p.CreatedOn).HasColumnName("CreatedOn");
            userPermissionBuilder.Property(p => p.CreatedOn).HasColumnName("UpdatedOn");

            //Config Foreign Keys (many to many Relationship)
            userPermissionBuilder.HasOne(o => o.User).WithMany(m => m.Permissions).HasForeignKey(fk => fk.UserId);

            userPermissionBuilder.HasOne(o => o.Permission).WithMany(m => m.Users).HasForeignKey(fk => fk.PermissionId);

            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsUserPermissionsTable(EntityTypeBuilder<ApplicationUserPermission> builder)
        {
            //Seeding Data ------------------------------------------------
            builder.HasData(new List<ApplicationUserPermission>()
            {
                new ApplicationUserPermission()
                {
                    UserId=Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                    PermissionId=(int)PermissionType.CanInsert,
                    CreatedOn=DateTime.Now,
                    UpdatedOn=DateTime.Now
                },
                new ApplicationUserPermission()
                {
                    UserId=Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                    PermissionId=(int)PermissionType.CanUpdate,
                    CreatedOn=DateTime.Now,
                    UpdatedOn=DateTime.Now
                },
                new ApplicationUserPermission()
                {
                    UserId=Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                    PermissionId=(int)PermissionType.CanDelete,
                    CreatedOn=DateTime.Now,
                    UpdatedOn=DateTime.Now
                },
                new ApplicationUserPermission()
                {
                    UserId=Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                    PermissionId=(int)PermissionType.CanView,
                    CreatedOn=DateTime.Now,
                    UpdatedOn=DateTime.Now
                },


            });
        }

        #endregion
    }
}
