using _0_Framework.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {

        private readonly IInventoryRepo _inventoryRepo;
        private readonly IAuthHelper _authHelper;

        public InventoryApplication(IInventoryRepo inventoryRepo, IAuthHelper authHelper)
        {
            _inventoryRepo = inventoryRepo;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operationResult = new OperationResult();
            if (_inventoryRepo.Exists(c => c.ProductId == command.ProductId))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepo.Create(inventory);
            _inventoryRepo.Save();
            return operationResult.Succeeded();


        }

        public OperationResult Edit(EditInventory command)
        {
            var operationResult = new OperationResult();

            var Inventory = _inventoryRepo.Get(command.Id);

            if (Inventory == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);

            }

            if (_inventoryRepo.Exists(c => c.ProductId == command.ProductId && c.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            Inventory.Edit(command.ProductId, command.UnitPrice);
            _inventoryRepo.Save();
            return operationResult.Succeeded();


        }

        public EditInventory GetForEdit(long id)
        {
            return _inventoryRepo.GetForEdit(id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepo.GetOperationLog(inventoryId);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operationresult = new OperationResult();
            var inventory = _inventoryRepo.Get(command.InventoryId);
            if (inventory == null)
            {
                return operationresult.Failed(ApplicationMessage.recordNotFound);
            }

            const long OperationId = 1;
            inventory.Increase(command.Count, OperationId, command.Description);
            _inventoryRepo.Save();
            return operationresult.Succeeded();



        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {

            var operationResult = new OperationResult();
            var OperationId = _authHelper.CurrentAcountId();


            foreach (var item in command)
            {
                var inventory = _inventoryRepo.GetByProductId(item.ProductId);
                inventory.Reduce(item.Count,OperationId, item.Description, item.OrderId);
            }

            _inventoryRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepo.Get(command.InventoryId);
            if (inventory == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

         
            var  OperationId = _authHelper.CurrentAcountId();
            inventory.Reduce(command.Count, OperationId, command.Description, 0);
            _inventoryRepo.Save();
            return operationResult.Succeeded();

        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepo.Search(searchModel);
        }
    }
}
