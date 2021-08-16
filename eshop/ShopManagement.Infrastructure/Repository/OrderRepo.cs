using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.Repository
{
    public class OrderRepo : RepositoryBase<long, Order>, IOrderRepo
    {
        private readonly DBContext _context;
        public OrderRepo(DBContext context) : base(context)
        {
            _context = context;
        }

        #region Implementation of IOrderRepo

        public double GetAmountBy(long orderId)
        {
            var result = _context.Orders.Select(c => new {c.Id, c.PayAmount})
                .First(c => c.Id == orderId).PayAmount;

            if (result !=null) return result;
                

            return 0;
        }

        #endregion
    }
}
