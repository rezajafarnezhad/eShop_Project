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
        private readonly IFileUploader _fileUploader;
        public ProductCategoryApplication(IProductCategoryRepo productCategoryRepo , IFileUploader fileUploader)
        {
            _productCategoryRepo = productCategoryRepo;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {

            OperationResult operationResult = new OperationResult();
            if (_productCategoryRepo.Exists(c => c.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            
            var Slug = command.Slug.Slugify();


            var picpath = $"{command.Slug}";



            var Picturename = _fileUploader.Upload(command.picture, picpath);


            var ProductCategory = new ProductCategory(command.Name, command.Description, Picturename, command.pictureAlt,
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


            var picpath = $"{command.Slug}";

         

            var Picturename = _fileUploader.Upload(command.picture, picpath) ;

            ProductCategory.Edit(command.Name, command.Description, Picturename, command.pictureAlt,
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

        public OperationResult NotShowinMainPage(long id)
        {
            OperationResult operationResult = new OperationResult();
            var Category = _productCategoryRepo.Get(id);
            if(Category == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            Category.NotShowinPage();
            _productCategoryRepo.Save();
            return operationResult.Succeeded();


        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepo.Search(searchModel);
        }

        public OperationResult ShowinMainPage(long id)
        {
            OperationResult operationResult = new OperationResult();
            var Category = _productCategoryRepo.Get(id);
            if (Category == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            Category.ShowinPage();
            _productCategoryRepo.Save();
            return operationResult.Succeeded();
        }
    }
}
