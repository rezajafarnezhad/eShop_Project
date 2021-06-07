using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(300).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(400).IsRequired();
            builder.Property(c => c.Message).HasMaxLength(2000).IsRequired();
            builder.Property(c => c.ProductId).IsRequired();

            builder.HasOne(c => c.Product).WithMany(c => c.Comments).HasForeignKey(c => c.ProductId);

        }
    }
}
