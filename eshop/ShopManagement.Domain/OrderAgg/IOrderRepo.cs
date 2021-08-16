using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepo : IRepository<long, Order>
    {
        double GetAmountBy(long orderId);
    }
}
