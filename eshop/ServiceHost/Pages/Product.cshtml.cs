using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Comment;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public ProductQueryModel Product;

        public void OnGet(string id)
        {
            Product = _productQuery.GetDetails(id);

        }


        public IActionResult OnPost(AddComment command, string Slug)
        {

            _commentApplication.AddComment(command);

            return RedirectToPage("/Product", new { Id = Slug });

        }
    }
}
