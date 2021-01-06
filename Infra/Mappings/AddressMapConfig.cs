using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class AddressMapConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESS");

            builder.Property(a => a.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(a => a.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(a => a.State).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("STATE");

            builder.Property(a => a.City).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("CITY");

            builder.Property(a => a.Neighborhood).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NEIGHBORHOOD");

            builder.Property(a => a.Street).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("STREET");

            builder.Property(a => a.Number).IsRequired().HasColumnType("VARCHAR(6)").HasColumnName("NUMBER");

            builder.HasOne(a => a.User).WithOne(u => u.Address).HasForeignKey<User>(a => a.AddressId).IsRequired(false);

            builder.HasOne(a => a.Restaurant).WithOne(r => r.Address).HasForeignKey<Restaurant>(a => a.AddressId).IsRequired(false);
        }
    }
}
