using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepo _productPictureRepo;

        public ProductPictureApplication(IProductPictureRepo productPictureRepo)
        {
            _productPictureRepo = productPictureRepo;
        }

        public OperationResult Create(CreateProductPicture Command)
        {
            var OperationResult = new OperationResult();

            if (_productPictureRepo.Exists(c => c.PictureName == Command.PictureName && c.ProductId == Command.ProductId))
            {
                return OperationResult.Failed(ApplicationMessage.duplicated);
            }

            var productPic = new ProductPicture(Command.ProductId, Command.PictureName, Command.PictureAlt, Command.PictureTitle);
            _productPictureRepo.Create(productPic);
            _productPictureRepo.Save();
            return OperationResult.Succeeded();

        }

        public OperationResult Edit(EditproductPicture Command)
        {
            var OperationResult = new OperationResult();
            var productpic = _productPictureRepo.Get(Command.Id);

            if (productpic == null)
            {
                return OperationResult.Failed(ApplicationMessage.recordNotFound);

            }

            if (_productPictureRepo.Exists(c => c.PictureName == Command.PictureName && c.ProductId == Command.ProductId && c.Id != Command.Id))
            {
                return OperationResult.Failed(ApplicationMessage.duplicated);

            }

            productpic.Edit(Command.ProductId, Command.PictureName, Command.PictureAlt, Command.PictureTitle);
            _productPictureRepo.Save();
            return OperationResult.Succeeded();

        }

        public EditproductPicture GetForEdit(long id)
        {
            return _productPictureRepo.GetForEdit(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepo.Search(searchModel);
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var productPic = _productPictureRepo.Get(id);
            if (productPic == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }
            productPic.Remove();
            _productPictureRepo.Save();
            return operationResult.Succeeded();


        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var productPic = _productPictureRepo.Get(id);
            if (productPic == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }
            productPic.Restore();
            _productPictureRepo.Save();
            return operationResult.Succeeded();
        }
    }
}
