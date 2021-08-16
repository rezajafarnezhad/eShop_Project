using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
   public interface ICartService
   {
       void Set(Cart cart);

       Cart Get();
   }
}
