using _0_Framework.Application;
using _01_eshopQuery.Contracts.Article;
using _01_eshopQuery.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public ArticleCategoryQueryModel GetArtcleByCategorySlug(string slug)
        {
            var article =  _context.ArticleCategories
                .Include(c => c.Articles)
               .Select(c => new ArticleCategoryQueryModel()
               {
                   Name = c.Name,
                   ArticleCount = c.Articles.Count,
                   Slug = c.Slug,
                   Articles = MapArticles(c.Articles)

               }).FirstOrDefault(c => c.Slug == slug);

            return article;
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
            return articles.Where(c=>!c.IsRemoved).Select(c => new ArticleQueryModel()
            {
                Title = c.Title,
                CategoryId = c.CategoryId,
                CanonicalAddress = c.CanonicalAddress,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                PublishDate = c.PublishDate.ToFarsi(),
                ShortDescription = c.ShortDescription.Substring(0, Math.Min(c.ShortDescription.Length, 120)) + "....",
                Slug = c.Slug,
                MetaDescription =c.MetaDescription,
                Description=c.Description,
                IsRemoved=c.IsRemoved,
                KeyWords=c.KeyWords
            }).ToList();

        }

        public List<ArticleCategoryQueryModel> GetArticleCategory()
        {
            return _context.ArticleCategories.Include(c => c.Articles.Where(c=>!c.IsRemoved))
                 .Select(c => new ArticleCategoryQueryModel()
                 {
                     Name = c.Name,
                     ArticleCount = c.Articles.Count,
                     Slug = c.Slug

                 }).OrderByDescending(c => c.Name).ToList();
        }
    }
}
