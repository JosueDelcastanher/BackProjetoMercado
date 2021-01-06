using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(u => u.Email).HasMaxLength(100).HasColumnType("VARCHAR(100)").IsRequired().HasColumnName("EMAIL");
            builder.HasIndex(u => u.Email).IsUnique(true);

            builder.Property(u => u.Password).HasMaxLength(16).HasColumnType("VARCHAR(255)").IsRequired().HasColumnName("PASSWORD");

            builder.HasOne(a => a.Address).WithOne(u => u.User).HasForeignKey<Address>(a => a.UserId).IsRequired(false);

            builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(u => u.UserId);

            builder.HasMany(a => a.Comments).WithOne(u => u.User).HasForeignKey(x => x.UserId).IsRequired();
        }
    }
}
