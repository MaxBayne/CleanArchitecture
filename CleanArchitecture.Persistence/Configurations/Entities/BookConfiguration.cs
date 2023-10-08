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
            builder.HasKey(u => u.Id);

            //Seeding Data ------------------------------------------------



            //Seed books
            builder.HasData(new List<Book>()
            {
                new Book(-1,"OOP C#","Lean OOP inside C#","Programming",true),
                new Book(-2,"Rust","Lean Rust Programming","Programming",true),
                new Book(-3,"Android","Lean Android Programming","Mobile",true),
                new Book(-4,"Flutter","Lean Flutter Programming","Mobile",true),
                new Book(-5,"DevExpress","Lean DevExpress For Desktop Apps","Desktop",false),
                new Book(-6,"EntityFrameworkCore","Lean EntityFrameworkCore","DataAccess",false)
            });
        }
    }
}
