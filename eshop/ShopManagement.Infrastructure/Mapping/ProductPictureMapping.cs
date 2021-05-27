using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PictureName).HasMaxLength(1200).IsRequired();
            builder.Property(c => c.PictureAlt).HasMaxLength(500);
            builder.Property(c => c.PictureTitle).HasMaxLength(500);


            builder.HasOne(c => c.Product).WithMany(c => c.ProductPictures).HasForeignKey(c => c.ProductId);

        }
    }
}
