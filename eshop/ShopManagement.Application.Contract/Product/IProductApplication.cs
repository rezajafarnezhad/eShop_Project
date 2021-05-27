using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetForEdit(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
       
        OperationResult Instock(long id);
        OperationResult outOfstock(long id);

        List<ProductViewModel> GetProducts();

    }
}
