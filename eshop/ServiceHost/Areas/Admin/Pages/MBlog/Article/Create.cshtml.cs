using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
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

        public void OnGet()
        {
            Categories = new SelectList(_articleCategoryApplication.GetArticleCategory(), "Id", "Name");
        }

        public IActionResult OnPost(CreateArticle createArticle)
        {
            var result = _articleApplication.Create(createArticle);
            return RedirectToPage("./Index");

        }
    }
}
