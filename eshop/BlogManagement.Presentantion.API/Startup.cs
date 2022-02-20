using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Configuration;
using BlogManagementBootstrapper;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using ServiceHost;
using ShopManagement.Configuration;

namespace BlogManagement.Presentantion.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            var ConnectionString = Configuration.GetConnectionString("EShopDB");
            services.AddHttpContextAccessor();

            services.AddTransient<IFileUploader, FileUploade>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            ShopManagementBootstrapper.Configure(services, ConnectionString);
            DiscountManagemantBootstrapper.Configure(services, ConnectionString);
            InventoryManagemantBootstrapper.Configure(services, ConnectionString);
            blogManagementBootstrapper.Configure(services, ConnectionString);
            AccountManagementBootstrapper.Configure(services, ConnectionString);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogManagement.Presentantion.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogManagement.Presentantion.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
