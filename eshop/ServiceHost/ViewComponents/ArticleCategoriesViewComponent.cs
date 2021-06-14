using _01_eshopQuery.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class ArticleCategoriesViewComponent : ViewComponent
    {

        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleCategoriesViewComponent(IArticleCategoryQuery articleCategoryQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {

            var model = _articleCategoryQuery.GetArticleCategory();

            return View(model);

        }

    }
}
