namespace ShopManagement.Application.Contract.Order
{
    public class OrderItemViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public int DiscountRate { get; set; }

        public long OrderId { get; set; }
    }
}