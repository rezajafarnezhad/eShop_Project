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
using ShopManagement.Application.Contract.Slide;

namespace ServiceHost.Areas.Admin.Pages.MShop.Slides
{
    public class IndexModel : PageModel
    {

        public List<SlideViewModel> slides { get; set; }


        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            slides = _slideApplication.GetList();

        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetForEdit(id);
            return Partial("./Edit", slide);
        }


        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);

        }


        [TempData]
        public string message { get; set; }

        public IActionResult OnPostRemove(int id)
        {
            var result = _slideApplication.Remove(id);
            if (result.isSucceeded)
                return RedirectToPage("./Index");

            message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnPostRestore(int id)
        {
            var result = _slideApplication.Restore(id);
            if (result.isSucceeded)
                return RedirectToPage("./Index");

            message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
