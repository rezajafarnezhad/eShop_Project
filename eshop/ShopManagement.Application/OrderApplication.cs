using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {

        private readonly IOrderRepo _orderRepo;
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        public OrderApplication(IOrderRepo orderRepo, IAuthHelper authHelper, IConfiguration configuration)
        {
            _orderRepo = orderRepo;
            _authHelper = authHelper;
            _configuration = configuration;
        }

        #region Implementation of IOrderApplication

        public long PlaceOrder(Cart cart)
        {

            var AccountId = _authHelper.CurrentAcountId();
            var order = new Order(AccountId, cart.TotalAmount, cart.DiscountAmount, cart.PayAmount,cart.paymentmothod);

            foreach (var Item in cart.items)
            {
                var OrderItem = new OrderItem(Item.id, Item.count, Item.doublePrice, Item.DiscountRate);
                order.AddItem(OrderItem);
            }
            _orderRepo.Create(order);
            _orderRepo.Save();
            return order.Id;
        }

        public string PaymentSucceeded(long orderId, long refId)
        {
            var order = _orderRepo.Get(orderId);
            order.PaymentSucceeded(refId);
            var IssueTrackingNo = CodeGenerator.Generate("S");
            order.SetIssueTrackingNo(IssueTrackingNo);
            //TO DO
            _orderRepo.Save();
            return IssueTrackingNo;
        }

        public double GetAmountBy(long orderid)
        {
            return _orderRepo.GetAmountBy(orderid);
        }

        #endregion
    }
}
