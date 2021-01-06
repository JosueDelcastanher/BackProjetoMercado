using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class CommentRestaurantMapConfig : IEntityTypeConfiguration<CommentRestaurant>
    {
        public void Configure(EntityTypeBuilder<CommentRestaurant> builder)
        {
            builder.ToTable("COMMENT_RESTAURANT");

            builder.Property(a => a.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(a => a.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(a => a.Commentary).IsRequired().HasColumnType("VARCHAR(255)").HasColumnName("COMENTARIO");

            builder.Property(a => a.IsGood).IsRequired().HasDefaultValue(true).HasColumnType("BIT").HasColumnName("IsGood");

            builder.HasOne(x => x.Restaurant).WithMany(x => x.Comments).HasForeignKey(x => x.RestaurantId);

            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.RestaurantId);
        }
    }
}
