using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.MDiscounts.ColleagueDiscount
{
    public class IndexModel : PageModel
    {

        public List<ColleagueDiscountViewModel> ColleagueDiscounts { get; set; }
        public ColleagueDiscountSearchModel SearchModel;
        public SelectList Products;


        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;

        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {

            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");

        }


        public IActionResult OnGetCreate()
        {
            var defineColleagueDiscount = new DefineColleagueDiscount();
            defineColleagueDiscount.Products = _productApplication.GetProducts();
            return Partial("./Create", defineColleagueDiscount);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var EditColleagueDiscount = _colleagueDiscountApplication.GetForEdit(id);
            EditColleagueDiscount.Products = _productApplication.GetProducts();
            return Partial("./Edit", EditColleagueDiscount);
        }


        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);

        }


        public IActionResult OnPostRemove(long id)
        {
            var result = _colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostRestore(long id)
        {
            var result = _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
