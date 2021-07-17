using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.InfrastructureEFCore;
using AccountManagement.InfrastructureEFCore.Repository;
using InventoryManagement.Configuration.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string ConnectionString)
        {

            services.AddTransient<IAccountRepo, AccountRepo>();
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IRoleApplication, RoleApplication>();

            services.AddTransient<IPermissionExposer, AccountPermissionExposer>();

            services.AddDbContext<AccountContext>(c => c.UseSqlServer(ConnectionString));


        }
    }

}
