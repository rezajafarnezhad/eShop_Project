using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.Mapping
{
   public class OrderMapping:IEntityTypeConfiguration<Order>
    {
        #region Implementation of IEntityTypeConfiguration<Order>

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsSueTrackingNo).HasMaxLength(10);

            builder.OwnsMany(c => c.Items, navigationBuilder =>
            {

                navigationBuilder.ToTable("OrderItem");
                navigationBuilder.HasKey(c => c.Id);
                navigationBuilder.WithOwner(c => c.Order).HasForeignKey(c => c.OrderId);

            });


        }

        #endregion
    }
}
