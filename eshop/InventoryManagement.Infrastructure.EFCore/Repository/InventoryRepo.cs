using _0_Framework.Application;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.InfrastructureEFCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepo : RepositoryBase<long, Inventory>, IInventoryRepo
    {

        private readonly InventoryContext _context;
        private readonly DBContext _shopcontext;
        private readonly AccountContext _accountContext;
        public InventoryRepo(InventoryContext context, DBContext shopcontext, AccountContext accountContext) : base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
            _accountContext = accountContext;
        }

        public Inventory GetByProductId(long productid)
        {
            return _context.Inventory.FirstOrDefault(c => c.ProductId == productid);
        }

        public EditInventory GetForEdit(long id)
        {
            var Inventory = _context.Inventory.Find(id);
            return new EditInventory()
            {
                Id = Inventory.Id,
                ProductId = Inventory.ProductId,
                UnitPrice = Inventory.UnitPrice
            };
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var account = _accountContext.Accounts.Select(c => new { c.Id, c.FullName }).ToList();
            var inventory = _context.Inventory.Find(inventoryId);
            var log = inventory.Operations.Select(c => new InventoryOperationViewModel()
            {
                Id = c.Id,
                Count = c.Count,
                Description = c.Description,
                CurrentCount = c.CurrentCount,
                Operation = c.Operation,
                OperatorId = c.OperatorId,
                OpetationDate = c.OpetationDate.ToFarsiFull(),
                OrderId = c.OrderId

            }).OrderByDescending(c => c.Id).ToList();

            foreach (var operation in log)
            {
                operation.OperatorName = account
                    .FirstOrDefault(c => c.Id == operation.OperatorId)?.FullName;
            }

            return log;
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var query = _context.Inventory.Select(c => new InventoryViewModel()
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToFarsi(),
                InStock = c.InStock,
                CurrentCount = c.CalculateCurrentCount(),
                ProductId = c.ProductId,
                UnitPrice = c.UnitPrice
            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(c => c.ProductId == searchModel.ProductId);
            }

            if (searchModel.InStock)
            {
                query = query.Where(c => !c.InStock);
            }

            var Products = _shopcontext.Products.Select(c => new { c.Id, c.Name }).ToList();

            var inventory = query.OrderByDescending(c => c.Id).ToList();

            inventory.ForEach(
                item => item.ProductName = Products.FirstOrDefault(c => c.Id == item.ProductId)?.Name);

            return inventory;


        }
    }
}
