using DiscountManagement;
using ShopManagement.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using _0_Framework.Application;
using BlogManagementBootstrapper;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AccountManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using _0_Framework.Infrastructure;

namespace ServiceHost
{
    //sdss

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



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea", builder => builder.RequireRole(new List<string> { "1", "2", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", }));
            });

            services.AddHttpContextAccessor();

            var ConnectionString = Configuration.GetConnectionString("EShopDB");

            #region IOC

            ShopManagementBootstrapper.Configure(services, ConnectionString);
            DiscountManagemantBootstrapper.Configure(services, ConnectionString);
            InventoryManagemantBootstrapper.Configure(services, ConnectionString);
            blogManagementBootstrapper.Configure(services, ConnectionString);
            AccountManagementBootstrapper.Configure(services, ConnectionString);

            services.AddTransient<IFileUploader, FileUploade>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            #endregion



            services.AddSingleton(
                HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

            services.AddRazorPages()
                .AddMvcOptions(op => op.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminArea");

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
