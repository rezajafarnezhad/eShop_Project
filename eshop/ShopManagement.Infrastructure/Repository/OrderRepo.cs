using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.InfrastructureEFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.Repository
{
    public class OrderRepo : RepositoryBase<long, Order>, IOrderRepo
    {
        private readonly DBContext _context;
        private readonly AccountContext _accountContext;
        public OrderRepo(DBContext context, AccountContext accountContext) : base(context)
        {
            _context = context;
            _accountContext = accountContext;
        }

        #region Implementation of IOrderRepo

        public double GetAmountBy(long orderId)
        {
            var result = _context.Orders.Select(c => new { c.Id, c.PayAmount })
                .First(c => c.Id == orderId).PayAmount;

            if (result != null) return result;


            return 0;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var accounts = _accountContext.Accounts.Select(c => new { c.Id, c.FullName }).ToList();


            var query = _context.Orders.Select(c => new OrderViewModel()
            {
                Id = c.Id,
                AccountId = c.AccountId,
                DiscountAmount = c.DiscountAmount,
                IsCanceled = c.IsCanceled,
                IsPaid = c.IsPaid,
                RefId = c.RefId,
                PayAmount = c.PayAmount,
                IsSueTrackingNo = c.IsSueTrackingNo,
                TotalAmount = c.TotalAmount,
                CaretioonDate = c.CreationDate.ToFarsi(),
                PaymentMethodId = c.PaymentMethod,


            });


            query = query.Where(c => c.IsCanceled == searchModel.IsCanceled);

            if (searchModel.AccountId > 0)
            {
                query = query.Where(c => c.AccountId == searchModel.AccountId);
            }

            var orders = query.OrderByDescending(c => c.Id).ToList();

            foreach (var order in orders)
            {
                order.AccountFullName = accounts
                    .FirstOrDefault(c => c.Id == order.AccountId)?.FullName;

                order.PaymentMethodName = PaymentMethod.GetBy(order.PaymentMethodId).Name;
            }

            return orders;

        }

        public List<OrderItemViewModel> GetItems(long orderid)
        {
            var Products = _context.Products.Select(c => new {c.Id, c.Name}).ToList();
            var order = _context.Orders.FirstOrDefault(c => c.Id == orderid);
            if (order == null)
            {
                return new List<OrderItemViewModel>();
            }

            var items = order.Items.Select(c => new OrderItemViewModel()
            {
                Id = c.Id,
                Count = c.Count,
                UnitPrice = c.UnitPrice,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate,
                OrderId = c.OrderId


            }).ToList();

            foreach (var item in items)
            {
                item.ProductName = Products.FirstOrDefault(c => c.Id == item.ProductId)?.Name;
            }


            return items;

        }

        #endregion
    }
}
