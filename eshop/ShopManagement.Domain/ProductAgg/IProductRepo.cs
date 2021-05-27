using _0_Framework.Domain;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepo : IRepository<long, Product>
    {
        EditProduct GetEdit(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();

    }
}
