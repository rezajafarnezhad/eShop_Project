namespace ShopManagement.Application.Contract.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string AccountFullName { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public string IsSueTrackingNo { get; set; }
        public long RefId { get; set; }
        public string CaretioonDate { get; set; }
    }
}