namespace InventoryManagement.Application.Contracts.Inventory
{
    public class IsInStock
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }
}