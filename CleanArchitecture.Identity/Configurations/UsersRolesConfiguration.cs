using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

namespace CleanArchitecture.Identity.Configurations
{
    public class UsersRolesConfiguration : IEntityTypeConfiguration<AppUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<AppUserRole<Guid>> builder)
        {
            //Config Table ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<AppUserRole<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("UsersRoles", "Identity");

            //Config Primary Key
            //builder.HasKey(userRole=> new { userRole.UserId, userRole.RoleId });

            //Config Columns


            //Config Shared


            //Config Navigation

            //Config Foreign Keys (many to many Relationship)
            builder.HasOne(o => o.User)
                   .WithMany(m => m.UserRoles)
                   .HasForeignKey(fk => fk.UserId);

            builder.HasOne(o => o.Role)
                   .WithMany(m => m.UserRoles)
                   .HasForeignKey(fk => fk.RoleId);
        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<AppUserRole<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------

            //Seed Users Roles

            //Admin User Related to Roles (Administrators,Supervisors,Users)
            builder.HasData(new List<AppUserRole<Guid>>()
            {

               new AppUserRole<Guid>
               {
                   UserId= Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("557D96C5-6AB6-40B9-B2A3-47166E861366")
               },

               new AppUserRole<Guid>
               {
                   UserId= Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("447D96C5-6AB6-40B9-B2A3-47166E861366")
               },

               new AppUserRole<Guid>
               {
                   UserId= Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366")
               }

            });

            //Supervisor User Related to Roles (Supervisors,Users)
            builder.HasData(new List<AppUserRole<Guid>>()
            {
               new AppUserRole<Guid>
               {
                   UserId= Guid.Parse("2b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("447D96C5-6AB6-40B9-B2A3-47166E861366")
               },

               new AppUserRole<Guid>
               {
                   UserId= Guid.Parse("2b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366")
               }
            });

            //user User Related to Roles (Users)
            builder.HasData(new List<AppUserRole<Guid>>()
            {
               new AppUserRole<Guid>
               {
                   UserId= Guid.Parse("3b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366")
               }
            });
        }

        #endregion

    }
}
