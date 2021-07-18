using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class CartItem
    {
        public long id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }

        public string Picture { get; set; }
        public string Slug { get; set; }
        public int Count { get; set; }
        public double TotalItemPrice { get; set; }

        public CartItem()
        {
            TotalItemPrice =UnitPrice * Count;
        }

    }
}
