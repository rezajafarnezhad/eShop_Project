using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contract.Order;

namespace ShopManagement.Application
{
    public class CartService : ICartService
    {
        /// <summary>
        ///Singleton
        /// </summary>

        public Cart Cart  { get; set; }


        public void Set(Cart cart)
        {
            Cart = cart;
        }

        public Cart Get()
        {
            return Cart;
        }

        
    }
}
