using _01_eshopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class MenueViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public MenueViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            

            return View();
        }
    }
}
