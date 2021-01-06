using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class RestaurantMapConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("RESTAURANT");

            builder.Property(a => a.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(a => a.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(a => a.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(a => a.ImagePath).IsRequired().HasColumnType("VARCHAR(255)").HasColumnName("IMAGE_PATH");

            builder.Property(a => a.CNPJ).IsRequired().HasColumnType("CHAR(18)").HasColumnName("CNPJ");

            builder.Property(a => a.Password).IsRequired().HasColumnType("VARCHAR(255)").HasColumnName("PASSWORD");

            builder.Property(a => a.Email).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("EMAIL");

            builder.HasMany(x => x.Snacks).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId).IsRequired();

            builder.HasMany(x => x.Comments).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId).IsRequired();

            builder.HasOne(a => a.Address).WithOne(u => u.Restaurant).HasForeignKey<Address>(a => a.RestaurantId).IsRequired(false);
        }
    }
}
