using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepo : RepositoryBase<long, Article>, IArticleRepo
    {
        private readonly BlogContext _context;

        public ArticleRepo(BlogContext context) : base(context)
        {
            _context = context;
        }

        public EditArticle GetForEdit(long id)
        {
            var article = _context.Articles.Find(id);
            return new EditArticle()
            {
                Id = article.Id,
                Description = article.Description,
                ShortDescription = article.ShortDescription,
                Slug = article.Slug,
                CanonicalAddress = article.CanonicalAddress,
                CategoryId = article.CategoryId,
                KeyWords = article.KeyWords,
                MetaDescription = article.MetaDescription,
                PictureAlt = article.PictureAlt,
                PictureTitle = article.PictureTitle,
                PublishDate =article.PublishDate.ToFarsi(),
                Title = article.Title,
            };
        }

        public Article GetWithCategory(long id)
        {
            return _context.Articles.Include(c => c.ArticleCategory).FirstOrDefault(c => c.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSeachModel seachModel)
        {
            var Query = _context.Articles
                .Include(article => article.ArticleCategory)
                .Select(article => new ArticleViewModel()
                {
                    Id = article.Id,
                    IsRemoved = article.IsRemoved,
                    Picture = article.Picture,
                    CategoryId = article.CategoryId,
                    CategoryName = article.ArticleCategory.Name,
                    PublishDate = article.PublishDate.ToFarsi(),
                    CreationDate = article.CreationDate.ToFarsi(),
                    Title = article.Title
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(seachModel.Title))
            {
                Query = Query.Where(c => c.Title.Contains(seachModel.Title));
            }
            if (seachModel.CategoryId > 0)
            {
                Query = Query.Where(c => c.CategoryId == seachModel.CategoryId);
            }

            return Query.OrderByDescending(c => c.Id).ToList();

        }
    }
}
