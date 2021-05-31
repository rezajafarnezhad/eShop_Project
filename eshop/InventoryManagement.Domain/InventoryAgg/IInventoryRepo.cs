using _0_Framework.Domain;
using InventoryManagement.Application.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepo : IRepository<long, Inventory>
    {

        EditInventory GetForEdit(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        Inventory GetByProductId(long productid);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);

    }
}
