using System.Collections.Generic;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagement.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ShopController(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        [HttpGet]
        public async Task<List<ProductQueryModel>> GetLatestArrivals()
        {
            return _productQuery.GetLatestArrivals();
        }
    }
}
