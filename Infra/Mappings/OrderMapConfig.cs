using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class OrderMapConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDER");

            builder.Property(o => o.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(o => o.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(o => o.DateTime).HasDefaultValueSql("getdate()").IsRequired().HasColumnType("DATETIME2").HasColumnName("DATE");

            builder.HasOne(o => o.DeliveryMan).WithMany(d => d.Orders).HasForeignKey(o => o.DeliveryManId).IsRequired(false);

            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

            builder.HasOne(o => o.Restaurant).WithMany(u => u.Orders).HasForeignKey(o => o.RestaurantId);
        }
    }
}
