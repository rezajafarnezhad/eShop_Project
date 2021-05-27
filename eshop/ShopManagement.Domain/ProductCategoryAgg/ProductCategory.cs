using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string picture { get; private set; }
        public string pictureAlt { get; private set; }
        public string pictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public List<Product> Products { get; set; }

        public ProductCategory(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            this.picture = picture;
            this.pictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            Products = new List<Product>();
        }


        public void Edit(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            this.picture = picture;
            this.pictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}
