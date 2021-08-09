using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems;
        private readonly IProductQuery _productQuery;

       const string cartItem = "cart_Item";


        public CartModel(IProductQuery productQuery)
        {
            CartItems = new List<CartItem>();
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();

            var Value = Request.Cookies[cartItem];
            
            var cartItems = serializer.Deserialize<List<CartItem>>(Value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice(); 
            }

            CartItems = _productQuery.CheckInventoryStatus(cartItems);
        }
        

        public IActionResult OnGetRemoveItem(long id)
        {

            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[cartItem];
            Response.Cookies.Delete(cartItem);
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            var itemToRemove = cartItems.FirstOrDefault(x => x.id == id);
            cartItems.Remove(itemToRemove);
            var options = new CookieOptions { Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append(cartItem, serializer.Serialize(cartItems), options);
            return RedirectToPage("/Cart");


        }

        public IActionResult OnGetGoToCheckOut()
        {

            var serializer = new JavaScriptSerializer();

            var Value = Request.Cookies[cartItem];

            var cartItems = serializer.Deserialize<List<CartItem>>(Value);
            foreach (var item in cartItems)
            {
                item.TotalItemPrice = item.doublePrice * item.count;
            }

            CartItems = _productQuery.CheckInventoryStatus(cartItems);
            if (CartItems.Any(c=> !c.IsInStock))
            {
                return RedirectToPage("/Cart");

            }

            return RedirectToPage("/CheckOut");

        }
    }
}
