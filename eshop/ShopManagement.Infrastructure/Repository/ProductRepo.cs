using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductRepo : RepositoryBase<long, Product>, IProductRepo
    {

        private readonly DBContext _context;

        public ProductRepo(DBContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetEdit(long id)
        {
            var product = _context.Products.Find(id);

            return new EditProduct()
            {
                Id = product.Id,
                Description = product.Description,
                MetaDescription = product.MetaDescription,
                ShortDescription = product.ShortDescription,
                CategoryId = product.CategoryId,
                Code = product.Code,
                KeyWords = product.KeyWords,
                Name = product.Name,
                Slug = product.Slug,
                picture = product.picture,
                pictureAlt = product.pictureAlt,
                pictureTitle = product.pictureTitle,
                UnitPrice = product.UnitPrice,

            };

        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(c => new ProductViewModel()
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(c => c.ProductCategory).Select(c => new ProductViewModel()
            {
                Id = c.Id,
                Code = c.Code,
                picture = c.picture,
                UnitPrice = c.UnitPrice,
                Name = c.Name,
                CategoryName = c.ProductCategory.Name,
                CategoryId = c.CategoryId,
                InStock = c.IsinStocke,
                CreationDate = c.CreationDate.ToString("dddd/MM/yyyy")
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(c => c.Name.Contains(searchModel.Name));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                query = query.Where(c => c.Code.Contains(searchModel.Code));
            }

            if (searchModel.CategoryId != 0)
            {
                query = query.Where(c => c.CategoryId == searchModel.CategoryId);
            }


            return query.OrderByDescending(c => c.Id).ToList();
        }
    }
}
