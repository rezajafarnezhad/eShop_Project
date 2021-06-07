using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Contracts.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string CategoryName { get; set; }
        public bool hasDiscount { get; set; }
        public string Discountexpirydate { get; set; }
        public string ShortDescription { get; set; }
        public string CategorySlug { get; set; }
        public bool isinstock { get; set; }
        public string Code { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductPicturesQueryModel> ProductPictures { get; set; }

        public List<CommentQueryModel> Comments { get; set; }
    }

    public class ProductPicturesQueryModel
    {
        public long ProductId { get; set; }
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemove { get; set; }

    }
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }

}
