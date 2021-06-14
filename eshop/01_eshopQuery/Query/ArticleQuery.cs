using _0_Framework.Application;
using _01_eshopQuery.Contracts.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {

        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
        }

        public ArticleQueryModel GetArticleBy(string Slug)
        {
            var Article =  _context.Articles.Include(c => c.ArticleCategory)
                 .Where(c => !c.IsRemoved && c.PublishDate <= DateTime.Now)
                 .Select(c => new ArticleQueryModel()
                 {
                     Title = c.Title,
                     CategoryId = c.CategoryId,
                     CanonicalAddress = c.CanonicalAddress,
                     CategoryName = c.ArticleCategory.Name,
                     Description = c.Description,
                     IsRemoved = c.IsRemoved,
                     KeyWords = c.KeyWords,
                     MetaDescription = c.MetaDescription,
                     Picture = c.Picture,
                     PictureAlt = c.PictureAlt,
                     PictureTitle = c.PictureTitle,
                     PublishDate = c.PublishDate.ToFarsi(),
                     ShortDescription = c.ShortDescription,
                     Slug = c.Slug,

                 }).FirstOrDefault(c => c.Slug == Slug);

            Article.KeywordList = Article.KeyWords.Split("#").ToList();

            return Article;
        }

        public List<ArticleQueryModel> GetLatestArrivalsArtticle()
        {
            return _context.Articles.Include(c => c.ArticleCategory)
                .Where(c => !c.IsRemoved && c.PublishDate <= DateTime.Now)
                .Select(c => new ArticleQueryModel()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.ArticleCategory.Name,
                    IsRemoved = c.IsRemoved,
                    Picture = c.Picture,
                    PictureAlt = c.PictureAlt,
                    PictureTitle = c.PictureTitle,
                    PublishDate = c.PublishDate.ToFarsi(),
                    ShortDescription = c.ShortDescription.Substring(0,Math.Min(c.ShortDescription.Length,120))+"....",
                    Slug = c.Slug,
                    Title = c.Title


                }).Take(8).ToList();



        }

    }
}
