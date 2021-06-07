using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;

namespace ServiceHost.Areas.Admin.Pages.MShop.Comment
{
    public class IndexModel : PageModel
    {



        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }


        public List<CommentViewModel> Comments { get; set; }



        public void OnGet()
        {
            Comments = _commentApplication.Comments();

        }

        public IActionResult OnGetReview(long id)
        {
            var commentReview = _commentApplication.Review(id);
            return Partial("./Review", commentReview);
        }

       



        public IActionResult OnPostCancel(long id)
        {
            var result = _commentApplication.Cancel(id);
            
                return RedirectToPage("./Index");

        }

        public IActionResult OnPostConfirm(long id)
        {
            var result = _commentApplication.Confirm(id);
            
                return RedirectToPage("./Index");

        }
    }
}
