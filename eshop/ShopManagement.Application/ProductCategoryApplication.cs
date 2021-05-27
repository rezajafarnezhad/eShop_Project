using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {

        private readonly IProductCategoryRepo _productCategoryRepo;

        public ProductCategoryApplication(IProductCategoryRepo productCategoryRepo)
        {
            _productCategoryRepo = productCategoryRepo;
        }

        public OperationResult Create(CreateProductCategory command)
        {

            OperationResult operationResult = new OperationResult();
            if (_productCategoryRepo.Exists(c => c.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var Slug = command.Slug.Slugify();

            var ProductCategory = new ProductCategory(command.Name, command.Description, command.picture, command.pictureAlt,
                command.pictureTitle, command.KeyWords, command.MetaDescription, Slug);

            _productCategoryRepo.Create(ProductCategory);
            _productCategoryRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            OperationResult operationResult = new OperationResult();

            var ProductCategory = _productCategoryRepo.Get(command.Id);
            if (ProductCategory == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            if (_productCategoryRepo.Exists(c => c.Name == command.Name && c.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var Slug = command.Slug.Slugify();
            ProductCategory.Edit(command.Name, command.Description, command.picture, command.pictureAlt,
                command.pictureTitle, command.KeyWords, command.MetaDescription, Slug);
            _productCategoryRepo.Save();
            return operationResult.Succeeded();
        }

        public EditProductCategory GetForEdit(long id)
        {
           return _productCategoryRepo.GetForEdit(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepo.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepo.Search(searchModel);
        }
    }
}
