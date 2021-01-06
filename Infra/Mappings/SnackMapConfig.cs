using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class SnackMapConfig : IEntityTypeConfiguration<Snack>
    {
        public void Configure(EntityTypeBuilder<Snack> builder)
        {
            builder.ToTable("SNACK");

            builder.Property(s => s.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(s => s.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(a => a.ImagePath).IsRequired().HasColumnType("VARCHAR(255)").HasColumnName("IMAGE_PATH");

            builder.Property(s => s.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(s => s.Price).IsRequired().HasColumnType("FLOAT").HasColumnName("PRICE");

            builder.Property(s => s.Description).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("DESCRIPTION");

            builder.HasOne(o => o.Restaurant).WithMany(u => u.Snacks).HasForeignKey(o => o.RestaurantId).IsRequired(false);
        }
    }
}
