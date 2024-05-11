using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class GamesGenresConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //Config Tables
            ConfigureTable(builder);

            //Seeds Data
            SeedsTable(builder);
        }


        #region Configure

        private void ConfigureTable(EntityTypeBuilder<Genre> builder)
        {
            //Config Table Schema ------------------------------------------------

            //Set table name and schema

            builder.ToTable("Genres", "OnlineStore");

            //Set primary key

            builder.HasKey(u => u.Id);

            //Configure properties

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            //Configure foreign key relationship
        }

        #endregion

        #region Seeds

        private void SeedsTable(EntityTypeBuilder<Genre> builder)
        {
            //Seeding Data ------------------------------------------------

            //Seed Genres
            builder.HasData(new List<Genre>()
            {
                Genre.Create(1,"Action"),
                Genre.Create(2,"War"),
                Genre.Create(3,"Family"),
                Genre.Create(4,"Tricks")
            });
        }

        #endregion

    }
}
