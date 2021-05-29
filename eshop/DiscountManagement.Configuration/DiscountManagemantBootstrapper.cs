using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscountManagement.Configuration
{
    public class DiscountManagemantBootstrapper
    {
        public static void Configure(IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<ICustomerDiscuntApplication, CustomerDiscuntApplication>();
            services.AddTransient<ICoustomerDiscountRepo, CoustomerDiscountRepo>();

            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddTransient<IColleagueDiscountRepo, ColleagueDiscountRepo>();




            services.AddDbContext<DiscountContext>(c => c.UseSqlServer(ConnectionString));



        }
    }
}
