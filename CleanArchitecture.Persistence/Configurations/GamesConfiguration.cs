using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class GamesConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            //Config Tables
            ConfigureTable(builder);

            //Seeds Data
            SeedsTable(builder);
        }


        #region Configure

        private void ConfigureTable(EntityTypeBuilder<Game> builder)
        {
            //Config Table Schema ------------------------------------------------

            //Set table name and schema

            builder.ToTable("Games", "OnlineStore");

            //Set primary key

            builder.HasKey(g => g.Id);


            //Configure properties

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c=>c.Price)
                   .IsRequired()
                   .HasPrecision(18,2);

            builder.Property(c => c.GenreId)
                   .IsRequired();

            //Configure foreign key relationship

            builder.HasOne(c=>c.Genre)
                   .WithMany()
                   .HasForeignKey(g => g.GenreId);

        }

        #endregion

        #region Seeds

        private void SeedsTable(EntityTypeBuilder<Game> builder)
        {
            //Seeding Data ------------------------------------------------

            //Seed Games
            builder.HasData(new List<Game>()
            {
                Game.Create(1,"Street Fighter",1,150,2010),
                Game.Create(2,"Call of Duty",2,98,2019),
                Game.Create(3,"Medal Of Honor",2,55,2018),
                Game.Create(4,"Need For Speed",3,870,2018),
                Game.Create(5,"Freedom Fighter",1,450,2017),
            });
        }

        #endregion

    }
}
