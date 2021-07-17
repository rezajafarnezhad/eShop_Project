using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Configuration.Permissions;

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

        [NeedsPermissions(ShopPermissions.ListProductCategories)]
        public void OnGet(ProductCategorySearchModel SearchModel)
        {

            productCategories = _productCategoryApplication.Search(SearchModel);
        }


        public IActionResult OnPostShow(long id)
        {
            var result = _productCategoryApplication.ShowinMainPage(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostNotShow(long id)
        {
            var result = _productCategoryApplication.NotShowinMainPage(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCreate()
        {
            var commnd = new CreateProductCategory();
            return Partial("./Create", commnd);
        }

        [NeedsPermissions(ShopPermissions.CrateProductCategories)]

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

        [NeedsPermissions(ShopPermissions.EditProductCategories)]

        public JsonResult OnPostEdit(EditProductCategory command)
        {

            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);

        }
    }
}
