using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //Config Table Schema ------------------------------------------------
            builder.ToTable("Sales.OrdersItems")
                   .HasKey(u => u.Id);

            builder.Property(p => p.AdditionsPercent).HasColumnType("decimal(18,3)");

            builder.Property(p => p.AdditionsValue).HasColumnType("decimal(18,3)");

            builder.Property(p => p.DiscountPercent).HasColumnType("decimal(18,3)");

            builder.Property(p => p.DiscountValue).HasColumnType("decimal(18,3)");

            builder.Property(p => p.Quantity).HasColumnType("decimal(18,3)");

            builder.Property(p => p.TaxPercent).HasColumnType("decimal(18,3)");

            builder.Property(p => p.TaxValue).HasColumnType("decimal(18,3)");

            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,3)");

            builder.Property(p => p.AdditionsPercent).HasColumnType("decimal(18,3)");

            builder.Property(p => p.AdditionsValue).HasColumnType("decimal(18,3)");

            builder.Property(p => p.DiscountPercent).HasColumnType("decimal(18,3)");

            builder.Property(p => p.DiscountValue).HasColumnType("decimal(18,3)");



            //Seeding Data ------------------------------------------------


        }
    }
}
