using System.Collections.Generic;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Areas.Admin.Pages.Inventory
{
  
    public class IndexModel : PageModel
    {
        public List<InventoryViewModel> Inventories { get; set; }
        public InventorySearchModel SearchModel;
        public SelectList Products;


        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public IndexModel(IProductApplication productApplication, IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {

            Inventories = _inventoryApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");

        }


        public IActionResult OnGetCreate()
        {
            var createInventory = new CreateInventory();
            createInventory.Products = _productApplication.GetProducts();
            return Partial("./Create", createInventory);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }




        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetForEdit(id);
            inventory.Products = _productApplication.GetProducts();
            return Partial("./Edit", inventory);

        }


        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);

        }


        public IActionResult OnGetIncrease(long id)
        {
            var increase = new IncreaseInventory() { InventoryId = id };
            return Partial("./Increase", increase);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetReduse(long id)
        {
            var Reduse = new ReduceInventory() { InventoryId = id };
            return Partial("./Reduse", Reduse);
        }

        public JsonResult OnPostReduse(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var operationInventory = _inventoryApplication.GetOperationLog(id);
            return Partial("./OperationLog", operationInventory);
        }


    }
}
