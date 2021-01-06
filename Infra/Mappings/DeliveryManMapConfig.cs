using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DeliveryManMapConfig : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.ToTable("DELIVERY_MAN");

            builder.Property(d => d.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(d => d.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(d => d.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(d => d.PIS).IsRequired().HasColumnType("CHAR(14)").HasColumnName("PIS");

            builder.Property(d => d.Salary).IsRequired().HasColumnType("FLOAT").HasColumnName("SALARY");

            builder.HasMany(d => d.Orders).WithOne(o => o.DeliveryMan).HasForeignKey(o => o.DeliveryManId);

        }
    }
}
