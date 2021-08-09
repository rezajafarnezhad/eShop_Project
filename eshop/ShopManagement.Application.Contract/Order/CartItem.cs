using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class CartItem
    {
        public long id { get; set; }
        public string name { get; set; }
        public double doublePrice { get; set; }
        public string picture { get; set; }
        public string slug { get; set; }
        public int count { get; set; }
        public double TotalItemPrice { get; set; }
        public bool IsInStock { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountAmout { get; set; }
        public double ItemPayAmount { get; set; }
        public CartItem()
        {
            TotalItemPrice = doublePrice * count;
        }

        public void CalculateTotalItemPrice()
        {
            TotalItemPrice = doublePrice * count;
        }

    }
}
