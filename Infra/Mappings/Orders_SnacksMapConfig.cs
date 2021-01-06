using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class Orders_SnacksMapConfig : IEntityTypeConfiguration<Order_Snack>
    {
        public void Configure(EntityTypeBuilder<Order_Snack> builder)
        {
            builder.ToTable("ORDERS_SNACKS");

            builder.HasKey(os => new { os.OrderId, os.SnackId });

            builder.HasOne(x => x.Snack).WithMany(x => x.Orders).HasForeignKey(x => x.SnackId);

            builder.HasOne(x => x.Order).WithMany(x => x.Snacks).HasForeignKey(x => x.OrderId);
        }
    }
}
