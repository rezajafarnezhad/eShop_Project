using _01_eshopQuery;
using _01_eshopQuery.Contracts.ArticleCategory;
using _01_eshopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class MenueViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenueViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {

            var model = new MenueModel()
            {
                ProductCategories = _productCategoryQuery.GetProductCategories(),
                ArticleCategories =_articleCategoryQuery.GetArticleCategory()
            };
            return View(model);
        }
    }
}
