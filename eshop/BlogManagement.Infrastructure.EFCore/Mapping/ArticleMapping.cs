using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
           

            builder.ToTable("Articles");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).HasMaxLength(400).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(2000);
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Picture).HasMaxLength(2000);
            builder.Property(c => c.PictureAlt).HasMaxLength(2000);
            builder.Property(c => c.PictureTitle).HasMaxLength(2000);
            builder.Property(c => c.Slug).IsRequired().HasMaxLength(400);
            builder.Property(c => c.MetaDescription).HasMaxLength(2000);
            builder.Property(c => c.KeyWords).HasMaxLength(400);
            builder.Property(c => c.CanonicalAddress).HasMaxLength(1400);

            builder.HasOne(c => c.ArticleCategory).WithMany(c => c.Articles).HasForeignKey(c => c.CategoryId);

        }
    }
}
