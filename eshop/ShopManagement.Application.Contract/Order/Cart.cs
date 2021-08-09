using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Order
{
    public class Cart
    {
        public List<CartItem> items { get; set; }

        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }


        public Cart()
        {
            items = new List<CartItem>();
        }
        public void Add(CartItem cartItem)
        {
            items.Add(cartItem);
            TotalAmount = TotalAmount + cartItem.TotalItemPrice;
            DiscountAmount = DiscountAmount + cartItem.DiscountAmout;
            PayAmount = PayAmount + cartItem.ItemPayAmount;

        }

    }
}
