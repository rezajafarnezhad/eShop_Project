using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBase
    {

        public long AccountId { get; private set; }
        public double TotalAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public double PayAmount { get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IsSueTrackingNo { get; private set; }
        public long RefId { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(long accountId, double totalAmount, double discountAmount,
            double payAmount)
        {
            AccountId = accountId;
            TotalAmount = totalAmount;

            DiscountAmount = discountAmount;
            PayAmount = payAmount;
           
            IsPaid = false;
            IsCanceled = false;
            RefId = 0;
            Items = new List<OrderItem>();
        }

        public void PaymentSucceeded(long refId)
        {
            IsPaid = true;

            if (RefId != 0) RefId = refId;
        }

        public void SetIssueTrackingNo(string number)
        {

            IsSueTrackingNo = number;

        }

        public void Cancel()
        {
            IsCanceled = true;
        }

        public void AddItem(OrderItem Item)
        {
            Items.Add(Item);
        }

    }
}
