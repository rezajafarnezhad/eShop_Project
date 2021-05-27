using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture Command);
        OperationResult Edit(EditproductPicture Command);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditproductPicture GetForEdit(long id);

    }
}
