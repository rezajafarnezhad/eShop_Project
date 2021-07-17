using _0_Framework.Infrastructure;
using _01_eshopQuery.Contracts.Article;
using _01_eshopQuery.Contracts.ArticleCategory;
using _01_eshopQuery.Query;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EFCore;
using BlogManagement.Infrastructure.EFCore.Repository;
using InventoryManagement.Configuration.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogManagementBootstrapper
{
    public class blogManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string ConnectionString)
        {

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepo, ArticleCategoryRepo>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();




            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepo, ArticleRepo>();
            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddTransient<IPermissionExposer, BlogPermissionExposer>();



            services.AddDbContext<BlogContext>(c => c.UseSqlServer(ConnectionString));
        }

    }
}
