using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Contracts.Inventory;

namespace _01_eshopQuery.Contracts.Inventory
{
    public interface IInventoryQuery
    {
        StockStatus ChackStock(IsInStock isInStock);


    }
}
