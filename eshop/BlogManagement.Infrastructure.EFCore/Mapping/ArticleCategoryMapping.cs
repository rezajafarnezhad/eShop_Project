using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);
            builder.Property(c => c.Description).HasMaxLength(1400);
            builder.Property(c => c.Slug).IsRequired().HasMaxLength(400);
            builder.Property(c => c.MetaDescription).HasMaxLength(1400);
            builder.Property(c => c.KeyWords).HasMaxLength(400);
            builder.Property(c => c.CanonicalAddress).HasMaxLength(1400);

            builder.HasMany(c => c.Articles).WithOne(c => c.ArticleCategory).HasForeignKey(c => c.CategoryId);

        }
    }
}
