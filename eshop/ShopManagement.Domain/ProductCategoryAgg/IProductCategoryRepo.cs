using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepo : IRepository<long, ProductCategory>
    {


        EditProductCategory GetForEdit(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();

    }
}
