using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<AppUser<Guid>>
    {
        public void Configure(EntityTypeBuilder<AppUser<Guid>> builder)
        {
            //Config Table ------------------------------------------------
            ConfigureTable(builder);

            //Seeding Data ------------------------------------------------
            SeedsTable(builder);
        }

        #region Configure

        private void ConfigureTable(EntityTypeBuilder<AppUser<Guid>> userBuilder)
        {
            //Config Table Schema ------------------------------------------------

            userBuilder.ToTable("Users", "Identity");

            //Config Primary Key

            //Config Columns

            //Config Shared


            //Config Navigation

        }

        #endregion

        #region Seeds

        // ReSharper disable once UnusedParameter.Local
        private void SeedsTable(EntityTypeBuilder<AppUser<Guid>> builder)
        {
            //Seeding Data ------------------------------------------------

            var hasher = new PasswordHasher<AppUser<Guid>>();

            //Seed Users
            builder.HasData(new List<AppUser<Guid>>()
            {
               new AppUser<Guid>
               {
                   Id=Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   UserName="admin",
                   NormalizedUserName="ADMIN",
                   Email="admin@gmail.com",
                   NormalizedEmail="ADMIN@GMAIL.COM",
                   PasswordHash=hasher.HashPassword(null,"P@ssw0rd"),
                   SecurityStamp = "123"
               },

               new AppUser<Guid>
               {
                   Id=Guid.Parse("2b345d5d-4714-401f-b124-32836d210679"),
                   UserName="supervisor",
                   NormalizedUserName="SUPERVISOR",
                   Email="supervisor@gmail.com",
                   NormalizedEmail="SUPERVISOR@GMAIL.COM",
                   PasswordHash=hasher.HashPassword(null,"P@ssw0rd"),
                   SecurityStamp = "123"
               },

               new AppUser<Guid>
               {
                   Id=Guid.Parse("3b345d5d-4714-401f-b124-32836d210679"),
                   UserName="user",
                   NormalizedUserName="USER",
                   Email="user@gmail.com",
                   NormalizedEmail="USER@GMAIL.COM",
                   PasswordHash=hasher.HashPassword(null,"P@ssw0rd"),
                   SecurityStamp = "123"
               }

            });
        }

        #endregion


    }
}
