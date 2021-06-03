using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchResultModel : PageModel
    {

        private readonly IProductQuery _productQuery;
        public SearchResultModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public List<ProductQueryModel> Products { get; set; }
        public string Value;

        public void OnGet(string value)
        {
            Products = _productQuery.Search(value);

            ViewData["Value"] = value;
        }
    }
}
