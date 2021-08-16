using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public interface IOrderApplication
    {

        long PlaceOrder(Cart cart);
        string PaymentSucceeded(long orderId,long refId);
        double GetAmountBy(long orderid);
    }
}
