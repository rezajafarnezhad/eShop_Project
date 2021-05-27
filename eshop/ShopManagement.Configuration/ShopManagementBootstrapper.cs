using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure;
using ShopManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string ConnectionString)
        {


            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepo, ProductCategoryRepo>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepo, ProductRepo>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepo, ProductPictureRepo>();


            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepo, SlideRepo>();

            services.AddDbContext<DBContext>(c => c.UseSqlServer(ConnectionString));

        }

    }
}
