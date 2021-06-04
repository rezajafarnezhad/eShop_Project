using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
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
        private readonly IProductRepo _productRepo;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepo productPictureRepo, IProductRepo productRepo, IFileUploader fileUploader)
        {
            _productPictureRepo = productPictureRepo;
            _productRepo = productRepo;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture Command)
        {
            var OperationResult = new OperationResult();

            var Product = _productRepo.GetProductWithCategory(Command.ProductId);

            var path = $"{Product.ProductCategory.Slug}/{Product.Slug}";

            var PicturePath = _fileUploader.Upload(Command.PictureName, path);

            var productPic = new ProductPicture(Command.ProductId, PicturePath, Command.PictureAlt, Command.PictureTitle);
            _productPictureRepo.Create(productPic);
            _productPictureRepo.Save();
            return OperationResult.Succeeded();

        }

        public OperationResult Edit(EditproductPicture Command)
        {
            var OperationResult = new OperationResult();
            var productpic = _productPictureRepo.GetWithProductAndcategorybyId(Command.Id);

            if (productpic == null)
            {
                return OperationResult.Failed(ApplicationMessage.recordNotFound);

            }

           

            var path = $"{productpic.Product.ProductCategory.Slug}/{productpic.Product.Slug}";

            var PicturePath = _fileUploader.Upload(Command.PictureName, path);

            productpic.Edit(Command.ProductId, PicturePath, Command.PictureAlt, Command.PictureTitle);
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
