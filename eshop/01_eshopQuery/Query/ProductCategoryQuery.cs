using _01_eshopQuery.Contracts.ProductCategory;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly DBContext _context;

        public ProductCategoryQuery(DBContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {

            return _context.ProductCategories.Where(c=>c.ShowinMainPage).Select(c => new ProductCategoryQueryModel()
            {
                Id = c.Id,
                Name = c.Name,
                picture = c.picture,
                pictureAlt = c.pictureAlt,
                pictureTitle = c.pictureTitle,
                Slug = c.Slug


            }).ToList();
        }
    }
}
