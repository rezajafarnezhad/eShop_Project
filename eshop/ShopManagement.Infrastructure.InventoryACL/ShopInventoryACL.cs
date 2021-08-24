using System;
using System.Collections.Generic;
using InventoryManagement.Application.Contracts.Inventory;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infrastructure.InventoryACL
{
    public class ShopInventoryACL : IShopInventoryACL
    {
        #region Implementation of IShopInventoryACL

        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryACL(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool ReduceFromInventory(List<OrderItem> items)
        {
            var command = new List<ReduceInventory>();
            foreach (var orderItem in items)
            {
                var item = new ReduceInventory(orderItem.ProductId, orderItem.Count,"خرید مشتری",orderItem.OrderId);
                command.Add(item);
            }

            return _inventoryApplication.Reduce(command).isSucceeded;
        }

        #endregion
    }
}
