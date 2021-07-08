using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.InfrastructureEFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.InfrastructureEFCore
{
    public class AccountContext : DbContext
    {

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asb = typeof(AccountMapping).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(asb);

            base.OnModelCreating(modelBuilder);
        }
    }
}
