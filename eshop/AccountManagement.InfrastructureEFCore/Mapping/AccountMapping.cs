using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.InfrastructureEFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.FullName).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Username).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(1000).IsRequired();
            builder.Property(c => c.Mobile).HasMaxLength(15).IsRequired();
            builder.Property(c => c.ProfilePicture).HasMaxLength(1000);

            builder.HasOne(c => c.Role).WithMany(c => c.Accounts)
                .HasForeignKey(c => c.RoleId);
        }
    }
}
