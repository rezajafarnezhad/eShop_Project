using _0_Framework.Application;
using _01_eshopQuery.Contracts.Product;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Query
{
    public class ProductQuery : IProductQuery
    {

        private readonly DBContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(DBContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductQueryModel> GetLatestArrivals()
        {
            var inventory = _inventoryContext.Inventory.Select(c => new { c.ProductId, c.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && c.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();



            var Products = _context.Products.Include(c => c.ProductCategory).Select(c => new ProductQueryModel()
            {
                Id = c.Id,
                Name = c.Name,
                CategoryName = c.ProductCategory.Name,
                Picture = c.picture,
                PictureAlt = c.pictureAlt,
                PictureTitle = c.pictureTitle,
                Slug = c.Slug

            }).AsNoTracking().Take(7).ToList();

            foreach (var Product in Products)
            {

                var inventorys = inventory.FirstOrDefault(c => c.ProductId == Product.Id);
                if (inventorys != null)
                {
                    var price = inventorys.UnitPrice;
                    Product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(c => c.ProductId == Product.Id);

                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        Product.DiscountRate = discountRate;
                        Product.hasDiscount = discountRate > 0;

                        var discountAmount = Math.Round((price * (int)discountRate) / 100);

                        Product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return Products;
        }

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryContext.Inventory.Select(c => new { c.ProductId, c.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && c.EndDate > DateTime.Now)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();



            var query = _context.Products.Include(c=>c.ProductCategory)
                .Select(c => new ProductQueryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CategoryName = c.ProductCategory.Name,
                    CategorySlug = c.ProductCategory.Slug,
                    Picture = c.picture,
                    PictureAlt = c.pictureAlt,
                    PictureTitle = c.pictureTitle,
                    Slug = c.Slug,
                    ShortDescription = c.ShortDescription

                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
            {
                query = query.Where(c => c.Name.Contains(value) || c.ShortDescription.Contains(value));
            }

            var Products = query.OrderByDescending(c => c.Id).ToList();

            foreach (var product in Products)
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

            return Products;
        }
    }
}
