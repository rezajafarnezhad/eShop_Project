using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {

        private readonly IOrderRepo _orderRepo;
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IShopInventoryACL _shopInventoryAcl;
        public OrderApplication(IOrderRepo orderRepo, IAuthHelper authHelper, IConfiguration configuration, IShopInventoryACL shopInventoryAcl)
        {
            _orderRepo = orderRepo;
            _authHelper = authHelper;
            _configuration = configuration;
            _shopInventoryAcl = shopInventoryAcl;
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
            if (_shopInventoryAcl.ReduceFromInventory(order.Items))
            {
                _orderRepo.Save();return IssueTrackingNo;
            }

            return "";

        }

        public double GetAmountBy(long orderid)
        {
            return _orderRepo.GetAmountBy(orderid);
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            return _orderRepo.Search(searchModel);
        }

        public void Cancel(long id)
        {
            var order = _orderRepo.Get(id);
            order.Cancel();
            _orderRepo.Save();

        }

        public List<OrderItemViewModel> GetItems(long orderid)
        {
            return _orderRepo.GetItems(orderid);
        }

        #endregion
    }
}
