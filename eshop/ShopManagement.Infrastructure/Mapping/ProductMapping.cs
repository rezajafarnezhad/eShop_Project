using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Slug).HasMaxLength(455).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(1000).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(560);
            builder.Property(c => c.picture).HasMaxLength(1200);
            builder.Property(c => c.pictureTitle).HasMaxLength(255);
            builder.Property(c => c.pictureAlt).HasMaxLength(255);
            builder.Property(c => c.Code).HasMaxLength(255).IsRequired();
            builder.Property(c => c.KeyWords).HasMaxLength(555).IsRequired();
            builder.Property(c => c.MetaDescription).HasMaxLength(655).IsRequired();
            


            builder.HasOne(c => c.ProductCategory).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId);
            builder.HasMany(c => c.ProductPictures).WithOne(c => c.Product).HasForeignKey(c => c.ProductId);

        }
    }
}
