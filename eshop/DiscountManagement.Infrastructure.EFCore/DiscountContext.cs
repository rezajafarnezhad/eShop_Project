using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EFCore
{
    public class DiscountContext : DbContext
    {

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }


        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }

        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asb = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asb);
        }


    }
}
