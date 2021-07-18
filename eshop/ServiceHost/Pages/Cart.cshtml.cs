using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> cartItems;

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();

            var Value = Request.Cookies["cart_Item"];

            cartItems = serializer.Deserialize<List<CartItem>>(Value);

            foreach (var item in cartItems)
            {
                item.TotalItemPrice = item.UnitPrice * item.Count;
            }


        }
    }
}
