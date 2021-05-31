using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        EditInventory GetForEdit(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(List<ReduceInventory> command);
        OperationResult Reduce(ReduceInventory command);

        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}
