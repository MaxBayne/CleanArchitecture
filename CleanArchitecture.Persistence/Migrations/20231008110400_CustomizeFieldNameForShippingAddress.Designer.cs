﻿// <auto-generated />
using System;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231008110400_CustomizeFieldNameForShippingAddress")]
    partial class CustomizeFieldNameForShippingAddress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Aggregates.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sales.Orders", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Library.Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Category = "Programming",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lean OOP inside C#",
                            IsActive = true,
                            Title = "OOP C#",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -2,
                            Category = "Programming",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lean Rust Programming",
                            IsActive = true,
                            Title = "Rust",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -3,
                            Category = "Mobile",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lean Android Programming",
                            IsActive = true,
                            Title = "Android",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -4,
                            Category = "Mobile",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lean Flutter Programming",
                            IsActive = true,
                            Title = "Flutter",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -5,
                            Category = "Desktop",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lean DevExpress For Desktop Apps",
                            IsActive = false,
                            Title = "DevExpress",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = -6,
                            Category = "DataAccess",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lean EntityFrameworkCore",
                            IsActive = false,
                            Title = "EntityFrameworkCore",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AdditionsPercent")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("AdditionsValue")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("TaxPercent")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Sales.OrdersItems", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Aggregates.Order", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.ObjectValues.ShippingAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("Apartment")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Apartment");

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Building");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("Floor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Floor");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Region");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.HasKey("OrderId");

                            b1.ToTable("Sales.Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("ShippingAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Aggregates.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Aggregates.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
