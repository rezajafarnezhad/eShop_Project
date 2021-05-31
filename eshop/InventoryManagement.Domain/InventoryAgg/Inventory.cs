﻿using _0_Framework.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {

        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var puls = Operations.Where(c => c.Operation).Sum(c => c.Count);

            var minus = Operations.Where(c => !c.Operation).Sum(c => c.Count);

            return puls - minus;
        }

        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;

            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);

            Operations.Add(operation);

            //if (currentCount>0)
            //{
            //    InStock = true;
            //}
            //else
            //{
            //    InStock = false;
            //}
            InStock = currentCount > 0;
        }


        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;

            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);

            Operations.Add(operation);

            InStock = currentCount > 0;
        }
    }
}
