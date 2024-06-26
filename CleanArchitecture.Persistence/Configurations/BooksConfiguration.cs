﻿using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //Config Tables
            ConfigureTable(builder);

            //Seeds Data
            SeedsTable(builder);
        }


        #region Configure

        private void ConfigureTable(EntityTypeBuilder<Book> builder)
        {
            //Config Table Schema ------------------------------------------------

            //Set table name and schema

            builder.ToTable("Books", "Library");

            //Set primary key

            builder.HasKey(u => u.Id);

            //Configure properties

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            //Configure foreign key relationship
        }

        #endregion

        #region Seeds

        private void SeedsTable(EntityTypeBuilder<Book> builder)
        {
            //Seeding Data ------------------------------------------------

            //Seed books
            builder.HasData(new List<Book>()
            {
                Book.Create(1,"OOP C#","Lean OOP inside C#","Programming",true),
                Book.Create(2,"Rust","Lean Rust Programming","Programming",true),
                Book.Create(3,"Android","Lean Android Programming","Mobile",true),
                Book.Create(4,"Flutter","Lean Flutter Programming","Mobile",true),
                Book.Create(5,"DevExpress","Lean DevExpress For Desktop Apps","Desktop",false),
                Book.Create(6,"EntityFrameworkCore","Lean EntityFrameworkCore","DataAccess",false)
            });
        }

        #endregion

    }
}
