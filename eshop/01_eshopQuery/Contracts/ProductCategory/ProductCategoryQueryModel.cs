using _01_eshopQuery.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string picture { get; set; }
        public string pictureAlt { get; set; }
        public string pictureTitle { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductQueryModel> Products { get; set; }

    }
}
