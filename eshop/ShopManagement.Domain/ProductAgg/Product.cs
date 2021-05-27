using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsinStocke { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; set; }
        public string picture { get; private set; }
        public string pictureAlt { get; private set; }
        public string pictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }


        public ProductCategory ProductCategory { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }




        public Product(string name, string code, double unitPrice, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, string keyWords, string metaDescription,
            string slug, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            this.picture = picture;
            this.pictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            IsinStocke = true;
            
        }

        public void Edit(string name, string code, double unitPrice, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, string keyWords, string metaDescription,
            string slug, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            this.picture = picture;
            this.pictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;

        }


        public void InStock()
        {
            IsinStocke = true;
        }

        public void OutofStock()
        {
            IsinStocke = false;
        }
    }
}
