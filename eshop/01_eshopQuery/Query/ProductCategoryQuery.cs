using _0_Framework.Application;
using _01_eshopQuery.Contracts.Product;
using _01_eshopQuery.Contracts.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
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
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(DBContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {

            return _context.ProductCategories.Where(c => c.ShowinMainPage).Select(c => new ProductCategoryQueryModel()
            {
                Id = c.Id,
                Name = c.Name,
                picture = c.picture,
                pictureAlt = c.pictureAlt,
                pictureTitle = c.pictureTitle,
                Slug = c.Slug


            }).AsNoTracking().ToList();
        }



        public List<ProductCategoryQueryModel> GetProductCategoryWithProducts()
        {
            var inventory = _inventoryContext.Inventory.Select(c => new { c.ProductId, c.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && c.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();



            var categories = _context.ProductCategories.Where(c => c.ShowinMainPage)
                .Include(c => c.Products)
                .ThenInclude(c => c.ProductCategory)
                .Select(c => new ProductCategoryQueryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = MapProducts(c.Products)
                }).ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var inventorys = inventory.FirstOrDefault(c => c.ProductId == product.Id);
                    if (inventorys != null)
                    {
                        var price = inventorys.UnitPrice;
                        product.Price = price.ToMoney();
                        var discount = discounts.FirstOrDefault(c => c.ProductId == product.Id);

                        if (discount != null)
                        {
                            int discountRate = discount.DiscountRate;
                            product.DiscountRate = discountRate;
                            product.hasDiscount = discountRate > 0;

                            var discountAmount = Math.Round((price * (int)discountRate) / 100);

                            product.PriceWithDiscount = (price - discountAmount).ToMoney();
                        }
                    }



                }
            }

            return categories;

        }
        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {

            return products.Select(c => new ProductQueryModel()
            {
                Id = c.Id,
                Name = c.Name,
                CategoryName = c.ProductCategory.Name,
                Picture = c.picture,
                PictureAlt = c.pictureAlt,
                PictureTitle = c.pictureTitle,
                Slug = c.Slug

            }).Take(6).ToList();
        }





        private static List<ProductQueryModel> MapProductsForCategoryDetails(List<Product> products)
        {

            return products.Select(c => new ProductQueryModel()
            {
                Id = c.Id,
                Name = c.Name,
                CategoryName = c.ProductCategory.Name,
                Picture = c.picture,
                PictureAlt = c.pictureAlt,
                PictureTitle = c.pictureTitle,
                Slug = c.Slug,


            }).ToList();
        }
        public ProductCategoryQueryModel GetProductCategoryWithProducts(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(c => new { c.ProductId, c.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && c.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();



            var category = _context.ProductCategories.Where(c => c.ShowinMainPage)
                .Include(c => c.Products)
                .ThenInclude(c => c.ProductCategory)
                .Select(c => new ProductCategoryQueryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = MapProductsForCategoryDetails(c.Products),
                    Slug = c.Slug,
                    KeyWords = c.KeyWords,
                    Description = c.Description,
                    MetaDescription = c.MetaDescription

                }).AsNoTracking().FirstOrDefault(c => c.Slug == slug);


            foreach (var product in category.Products)
            {
                var inventorys = inventory.FirstOrDefault(c => c.ProductId == product.Id);
                if (inventorys != null)
                {
                    var price = inventorys.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(c => c.ProductId == product.Id);

                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.hasDiscount = discountRate > 0;
                        product.Discountexpirydate = discount.EndDate.ToDiscountFormat();
                        var discountAmount = Math.Round((price * (int)discountRate) / 100);

                        product.PriceWithDiscount = (price - discountAmount).ToMoney();

                    }
                }

            }

            return category;
        }

        public List<ProductCategoryQueryModel> GetCategoryForMenue()
        {
            return _context.ProductCategories.Select(c => new ProductCategoryQueryModel()
            {
                Id = c.Id,
                Slug = c.Slug,
                Name = c.Name,
            }).AsNoTracking().ToList();
        }
    }
}
