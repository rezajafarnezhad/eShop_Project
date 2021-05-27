using _0_Framework.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
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

        public ProductApplication(IProductRepo productRepo)
        {
            _productRepo = productRepo;
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
            var Product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description,
                command.picture, command.pictureAlt, command.pictureTitle, command.KeyWords,
                command.MetaDescription, slug, command.CategoryId);

            _productRepo.Create(Product);
            _productRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Edit(EditProduct command)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepo.Get(command.Id);
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

            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description,
                command.picture, command.pictureAlt, command.pictureTitle, command.KeyWords,
                command.MetaDescription, slug, command.CategoryId);

            _productRepo.Save();
            return operationResult.Succeeded();

        }

        public EditProduct GetForEdit(long id)
        {
            return _productRepo.GetEdit(id);
        }

        

        public OperationResult Instock(long id)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepo.Get(id);
            if (product == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            product.InStock();
            _productRepo.Save();
            return operationResult.Succeeded();
        }

        public OperationResult outOfstock(long id)
        {

            OperationResult operationResult = new OperationResult();
            var product = _productRepo.Get(id);
            if (product == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            product.OutofStock();
            _productRepo.Save();
            return operationResult.Succeeded();
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
