using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepo : IRepository<long, ProductPicture>
    {

        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        EditproductPicture GetForEdit(long id);

        ProductPicture GetWithProductAndcategorybyId(long id);
    }
}
