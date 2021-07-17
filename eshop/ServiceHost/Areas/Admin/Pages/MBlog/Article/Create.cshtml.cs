using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagementBootstrapper.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.MBlog.Article
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public CreateArticle CreateArticle { get; set; }

        public SelectList Categories;

        [NeedsPermissions(BlogPermissions.CrateArticle)]

        public void OnGet()
        {
            Categories = new SelectList(_articleCategoryApplication.GetArticleCategory(), "Id", "Name");
        }

        [NeedsPermissions(BlogPermissions.CrateArticle)]

        public IActionResult OnPost(CreateArticle createArticle)
        {
            var result = _articleApplication.Create(createArticle);
            return RedirectToPage("./Index");

        }
    }
}
