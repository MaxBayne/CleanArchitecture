using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations.Entities
{
    public class BookConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //Config Table Schema ------------------------------------------------
            builder.ToTable("Library.Books");
            builder.HasKey(u=>u.Id);

            //Seeding Data ------------------------------------------------

            //Seed books
            builder.HasData(new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "OOP C#",
                    Description = "Lean OOP inside C#",
                    Category = "Programming",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Rust",
                    Description = "Lean Rust Programming",
                    Category = "Programming",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "Android",
                    Description = "Lean Android Programming",
                    Category = "Mobile",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new Book
                {
                    Id = 4,
                    Title = "Flutter",
                    Description = "Lean Flutter Programming",
                    Category = "Mobile",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new Book
                {
                    Id = 5,
                    Title = "DevExpress",
                    Description = "Lean DevExpress For Desktop Apps",
                    Category = "Desktop",
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                },
                new Book
                {
                    Id = 6,
                    Title = "EntityFrameworkCore",
                    Description = "Lean EntityFrameworkCore",
                    Category = "DataAccess",
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 1
                }
            });
        }
    }
}
