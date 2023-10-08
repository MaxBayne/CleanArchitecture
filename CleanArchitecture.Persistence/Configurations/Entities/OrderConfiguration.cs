using CleanArchitecture.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations.Entities
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Config Table Schema ------------------------------------------------
            builder.ToTable("Sales.Orders")
                   .HasKey(u => u.Id);

            builder.OwnsOne(order => order.ShippingAddress, o =>
            {
                o.Property(c => c.Country).HasColumnName("Country");
                o.Property(c => c.City).HasColumnName("City");
                o.Property(c => c.Region).HasColumnName("Region");
                o.Property(c => c.Street).HasColumnName("Street");
                o.Property(c => c.Building).HasColumnName("Building");
                o.Property(c => c.Floor).HasColumnName("Floor");
                o.Property(c => c.Apartment).HasColumnName("Apartment");
            });

            //Seeding Data ------------------------------------------------

           
        }
    }
}
