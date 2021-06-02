using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryPageModel : PageModel
    {

        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductCategoryPageModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }


        public ProductCategoryQueryModel ProductCategoryWithProduct;

        public void OnGet(string id)
        {
            ProductCategoryWithProduct = _productCategoryQuery.GetProductCategoryWithProducts(id);
        }
    }
}
