using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {

        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetForEdit(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
        OperationResult ShowinMainPage(long id);
        OperationResult NotShowinMainPage(long id);
    }
}
