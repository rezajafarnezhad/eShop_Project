using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepo : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepo
    {

        private readonly BlogContext _context;

        public ArticleCategoryRepo(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetArticleCategory()
        {
            return _context.ArticleCategories.Select(c => new ArticleCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name

            }).OrderByDescending(c => c.Name).ToList();
        }

        public EditArticleCategory GetForEdit(long id)
        {
            var category = _context.ArticleCategories.Find(id);

            return new EditArticleCategory()
            {
                id = category.Id,
                CanonicalAddress = category.CanonicalAddress,
                ShowOrder = category.ShowOrder,
                Slug = category.Slug,
                Description = category.Description,
                KeyWords = category.KeyWords,
                MetaDescription = category.MetaDescription,
                Name = category.Name
            };

        }

        public string GetSlugBy(long id)
        {
            return _context.ArticleCategories.Select(c => new { c.Id, c.Slug }).FirstOrDefault(c => c.Id == id).Slug;
        }

        public List<ArticleCategoryViewModel> Seach(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Select(c => new ArticleCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                ShowOrder = c.ShowOrder,
                CreationDate = c.CreationDate.ToFarsi(),
                Description = c.Description,
                ArticleCount = c.Articles.Count
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(c => c.Name.Contains(searchModel.Name));
            }

            return query.OrderByDescending(c => c.Id).ToList();

        }
    }
}
