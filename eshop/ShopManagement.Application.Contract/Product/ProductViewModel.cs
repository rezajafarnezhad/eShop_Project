namespace ShopManagement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string picture { get; set; }
        public string CategoryName { get; set; }
        public string CreationDate { get; set; }
        public long CategoryId { get; set; }
        
    }

}
