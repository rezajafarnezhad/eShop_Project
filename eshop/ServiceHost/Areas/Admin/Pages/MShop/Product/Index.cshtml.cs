using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Admin.Pages.MShop.Product
{
    public class IndexModel : PageModel
    {

        public List<ProductViewModel> Products { get; set; }
        public ProductSearchModel SearchModel;
        public SelectList ProductCategories;


        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;


        

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }


        [NeedsPermissions(ShopPermissions.ListProducts)]
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);

        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct();
            command.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Create", command);
        }


        [NeedsPermissions(ShopPermissions.CrateProducts)]
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var EditProduct = _productApplication.GetForEdit(id);
            EditProduct.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Edit", EditProduct);
        }


        [NeedsPermissions(ShopPermissions.EditProducts)]
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);

        }


      
    }
}
