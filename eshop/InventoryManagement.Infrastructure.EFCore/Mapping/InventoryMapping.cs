using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {

            builder.ToTable("Inventory");

            builder.HasKey(c => c.Id);

            builder.OwnsMany(c => c.Operations, ModelBuilder =>
            {

                ModelBuilder.ToTable("InventoryOperations");
                ModelBuilder.HasKey(c => c.Id);
                ModelBuilder.Property(c => c.Description).HasMaxLength(600);
                ModelBuilder.WithOwner(c => c.Inventory).HasForeignKey(c => c.InventoryId);
            });


        }
    }
}
