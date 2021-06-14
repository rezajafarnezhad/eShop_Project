using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.MBlog.Article
{
    public class IndexModel : PageModel
    {

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public List<ArticleViewModel> Articles { get; set; }

        public ArticleSeachModel SeachModel;
        public SelectList ArticleCategory;

        public void OnGet(ArticleSeachModel seachModel)
        {

            Articles = _articleApplication.Search(seachModel);
            ArticleCategory = new SelectList(_articleCategoryApplication.GetArticleCategory(),"Id","Name");
        }


        public IActionResult OnGetRemove(long id)
        {
            var result = _articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _articleApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
