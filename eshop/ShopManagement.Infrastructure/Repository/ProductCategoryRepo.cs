using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductCategoryRepo : RepositoryBase<long, ProductCategory>, IProductCategoryRepo
    {
        private readonly DBContext _context;

        public ProductCategoryRepo(DBContext context) : base(context)
        {
            _context = context;
        }



        public EditProductCategory GetForEdit(long id)
        {
            var productCategory = Get(id);
            return new EditProductCategory()
            {
                Id = productCategory.Id,
                Description = productCategory.Description,
                KeyWords = productCategory.KeyWords,
                MetaDescription = productCategory.MetaDescription,
                Name = productCategory.Name,
                picture = productCategory.picture,
                pictureAlt = productCategory.pictureAlt,
                pictureTitle = productCategory.pictureTitle,
                Slug = productCategory.Slug
            };
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(c => new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(c => new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationDate.ToString(),
                picture = c.picture,
                ProductCount = 0,
                ShowInMainPage=c.ShowinMainPage

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(c => c.Name.Contains(searchModel.Name));
            }

            return query.OrderByDescending(c => c.Id).ToList();
        }
    }
}
