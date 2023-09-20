using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations.Entities
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Config Table Schema ------------------------------------------------
            builder.ToTable("Membership.Users");
            builder.HasKey(u=>u.Id);

            //Seeding Data ------------------------------------------------

            //Seed Admins
            builder.HasData(new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "admin1",
                    Email = "admin1@gmail.com",
                    Password = "123",
                    Role = "admins",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new User()
                {
                    Id = 2,
                    Name = "admin2",
                    Email = "admin2@gmail.com",
                    Password = "123",
                    Role = "admins",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                }

            });

            //Seed Users
            builder.HasData(new List<User>()
            {
                new User()
                {
                    Id = 3,
                    Name = "user1",
                    Email = "user1@gmail.com",
                    Password = "456",
                    Role = "users",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new User()
                {
                    Id = 4,
                    Name = "user2",
                    Email = "user2@gmail.com",
                    Password = "456",
                    Role = "users",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                }

            });
        }
    }
}
