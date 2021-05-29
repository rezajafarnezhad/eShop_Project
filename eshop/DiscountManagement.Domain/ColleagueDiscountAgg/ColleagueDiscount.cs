using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }

        public bool IsRemoved { get; private set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemoved = false;

        }


        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }


        public void Remove()
        {
            IsRemoved = true;
        }


        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
