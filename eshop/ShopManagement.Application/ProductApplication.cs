using _0_Framework.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {

        private readonly IProductRepo _productRepo;
        private readonly IProductCategoryRepo _productCategoryRepo;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepo productRepo, IProductCategoryRepo productCategoryRepo, IFileUploader fileUploader)
        {
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProduct command)
        {
            OperationResult operationResult = new OperationResult();

            if (_productRepo.Exists(c => c.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }
            if (_productRepo.Exists(c => c.Code == command.Code))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }
            

            var slug = GenerateSlug.Slugify(command.Slug);

            var categorySlug = _productCategoryRepo.GetcategorySlugeby(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictuepath = _fileUploader.Upload(command.picture, path);


            var Product = new Product(command.Name, command.Code, command.ShortDescription, command.Description,
                pictuepath, command.pictureAlt, command.pictureTitle, command.KeyWords,
                command.MetaDescription, slug, command.CategoryId);

            _productRepo.Create(Product);
            _productRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Edit(EditProduct command)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepo.GetProductWithCategory(command.Id);
            if (product == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            if (_productRepo.Exists(c => c.Name == command.Name && c.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }
            if (_productRepo.Exists(c => c.Code == command.Code && c.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var slug = GenerateSlug.Slugify(command.Slug);

            var path = $"{product.ProductCategory.Slug}/{slug}";
            var pictuepath = _fileUploader.Upload(command.picture, path);

            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
               pictuepath, command.pictureAlt, command.pictureTitle, command.KeyWords,
                command.MetaDescription, slug, command.CategoryId);

            _productRepo.Save();
            return operationResult.Succeeded();

        }

        public EditProduct GetForEdit(long id)
        {
            return _productRepo.GetEdit(id);
        }


        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepo.Search(searchModel);
        }

        List<ProductViewModel> IProductApplication.GetProducts()
        {
            return _productRepo.GetProducts();
        }
    }
}
