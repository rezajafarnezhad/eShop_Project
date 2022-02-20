using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Inventory;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ShopManagement.Infrastructure;

namespace _01_eshopQuery.Query
{
    public class InventoryQuery:IInventoryQuery
    {
        private readonly InventoryContext _inventoryContext;
        private readonly DBContext _dbContext;

        public InventoryQuery(InventoryContext inventoryContext, DBContext dbContext)
        {
            _inventoryContext = inventoryContext;
            _dbContext = dbContext;
        }

        public StockStatus ChackStock(IsInStock isInStock)
        {

            var Inventory = _inventoryContext.Inventory.FirstOrDefault(c => c.ProductId == isInStock.ProductId);

            if (Inventory == null || Inventory.CalculateCurrentCount() < isInStock.Count)
            {
                var Product = _dbContext.Products.Select(c => new{ c.Id,c.Name}).FirstOrDefault(c => c.Id == isInStock.ProductId);

                return new StockStatus()
                {
                    IsStock = false,
                    ProductName =Product?.Name ,
                };
            }

            return new StockStatus()
            {
                IsStock = true,

            };
        }
    }
}
