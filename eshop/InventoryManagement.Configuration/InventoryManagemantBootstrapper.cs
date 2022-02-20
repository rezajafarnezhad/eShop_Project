using _0_Framework.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Configuration.Permissions;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Inventory;
using _01_eshopQuery.Query;

namespace InventoryManagement.Configuration
{
    public class InventoryManagemantBootstrapper
    {


        public static void Configure(IServiceCollection services, string ConnectionString)
        {

            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepo, InventoryRepo>();


            services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();

            services.AddScoped<IInventoryQuery, InventoryQuery>();


            services.AddDbContext<InventoryContext>(c => c.UseSqlServer(ConnectionString));



        }
    }

}
