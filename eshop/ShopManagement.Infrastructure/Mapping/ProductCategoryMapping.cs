using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(233).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(233).IsRequired();
            builder.Property(c => c.picture).HasMaxLength(2000).IsRequired();
            builder.Property(c => c.pictureAlt).HasMaxLength(233);
            builder.Property(c => c.pictureTitle).HasMaxLength(233);
            builder.Property(c => c.KeyWords).HasMaxLength(400).IsRequired();
            builder.Property(c => c.MetaDescription).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(c => c.Products).WithOne(c => c.ProductCategory).HasForeignKey(c => c.CategoryId);

        }
    }
}
