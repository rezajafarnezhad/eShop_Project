using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Inventory;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IInventoryQuery _inventoryQuery;
        public InventoryController(IInventoryApplication inventoryApplication, IInventoryQuery inventoryQuery)
        {
            _inventoryApplication = inventoryApplication;
            _inventoryQuery = inventoryQuery;
        }


        [HttpGet("{id}")]
        public async Task<List<InventoryOperationViewModel>> GetOperationLog(int id)
        {
            return _inventoryApplication.GetOperationLog(id);
        }


        [HttpPost]
        public async Task<StockStatus> ChackStock(IsInStock isInStock)
        {
            return _inventoryQuery.ChackStock(isInStock);
        }

    }
}
