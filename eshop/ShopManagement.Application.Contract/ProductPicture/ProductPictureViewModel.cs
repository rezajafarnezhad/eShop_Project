namespace ShopManagement.Application.Contract.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string PictureName { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
        public long  ProductId { get; set; }

    }

}
