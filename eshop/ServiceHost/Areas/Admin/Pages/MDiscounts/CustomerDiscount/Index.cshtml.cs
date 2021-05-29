using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.MDiscounts.CustomerDiscount
{
    public class IndexModel : PageModel
    {

        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }
        public CustomerDiscountSearchModel SearchModel;
        public SelectList Products;


        private readonly IProductApplication _productApplication;
        private readonly ICustomerDiscuntApplication _customerDiscuntApplication;

        public IndexModel(IProductApplication productApplication, ICustomerDiscuntApplication customerDiscuntApplication)
        {
            _productApplication = productApplication;
            _customerDiscuntApplication = customerDiscuntApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {

            CustomerDiscounts = _customerDiscuntApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(),"Id","Name");

        }


        public IActionResult OnGetCreate()
        {
            var defineDiscount = new DefineCustomerDiscount();
            defineDiscount.Products = _productApplication.GetProducts();
            return Partial("./Create", defineDiscount);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscuntApplication.Define(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var EditDiscount = _customerDiscuntApplication.GetForEdit(id);
            EditDiscount.Products = _productApplication.GetProducts();
            return Partial("./Edit", EditDiscount);
        }


        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscuntApplication.Edit(command);
            return new JsonResult(result);

        }


       
    }
}
