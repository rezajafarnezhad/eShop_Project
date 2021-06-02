using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();

    }
}
