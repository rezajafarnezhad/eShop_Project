using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagementBootstrapper.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.MBlog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }


        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        public ArticleCategorySearchModel searchModel { get; set; }

        [NeedsPermissions(BlogPermissions.ListArticleCategory)]
        public void OnGet(ArticleCategorySearchModel searchModel)
        {

            ArticleCategories = _articleCategoryApplication.Seach(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var commnd = new CreateArticleCategory();
            return Partial("./Create", commnd);
        }


        [NeedsPermissions(BlogPermissions.CrateArticleCategory)]

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var commnd = _articleCategoryApplication.GetForEdit(id);
            return Partial("./Edit", commnd);
        }


        [NeedsPermissions(BlogPermissions.EditArticleCategory)]

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var result = _articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
