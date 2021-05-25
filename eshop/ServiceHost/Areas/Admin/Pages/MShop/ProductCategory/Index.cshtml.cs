using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.MShop.ProductCategory
{
    public class IndexModel : PageModel
    {

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }


        public List<ProductCategoryViewModel> productCategories { get; set; }
        public ProductCategorySearchModel SearchModel { get; set; }


        public void OnGet(ProductCategorySearchModel SearchModel)
        {

            productCategories = _productCategoryApplication.Search(SearchModel);
        }

        public CreateProductCategory productCategory { get; set; }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", productCategory);
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var EditProductCategory = _productCategoryApplication.GetForEdit(id);
            return Partial("./Edit", EditProductCategory);
        }


        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);

        }
    }
}
