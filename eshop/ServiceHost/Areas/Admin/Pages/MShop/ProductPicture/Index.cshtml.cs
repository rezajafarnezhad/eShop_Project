using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;

namespace ServiceHost.Areas.Admin.Pages.MShop.ProductPicture
{
    public class IndexModel : PageModel
    {

        public List<ProductPictureViewModel> ProductPictures { get; set; }
        public ProductPictureSearchModel SearchModel;
        public SelectList Products;


        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication ;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductPictures = _productPictureApplication.Search(searchModel);

        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture();
            command.Products = _productApplication.GetProducts();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var EditProductPic = _productPictureApplication.GetForEdit(id);
            EditProductPic.Products = _productApplication.GetProducts();
            return Partial("./Edit", EditProductPic);
        }


        public JsonResult OnPostEdit(EditproductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);

        }


        [TempData]
        public string message { get; set; }

        public IActionResult OnPostRemove(int id)
        {
            var result = _productPictureApplication.Remove(id);
            if (result.isSucceeded)
                return RedirectToPage("./Index");

            message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnPostRestore(int id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.isSucceeded)
                return RedirectToPage("./Index");

            message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
