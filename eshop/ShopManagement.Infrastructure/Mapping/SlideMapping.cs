using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Picture).HasMaxLength(1200).IsRequired();
            builder.Property(c => c.PictureAlt).HasMaxLength(1200).IsRequired();
            builder.Property(c => c.PictureTitle).HasMaxLength(1200).IsRequired();
            builder.Property(c => c.Heading).HasMaxLength(1200);
            builder.Property(c => c.Text).HasMaxLength(1200);
            builder.Property(c => c.Title).HasMaxLength(1200);
            builder.Property(c => c.btnText).HasMaxLength(50);


        }
    }
}
