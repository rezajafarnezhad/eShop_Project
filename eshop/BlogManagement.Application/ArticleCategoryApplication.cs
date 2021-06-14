using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepo _articleCategoryRepo;

        public ArticleCategoryApplication(IArticleCategoryRepo articleCategoryRepo)
        {
            _articleCategoryRepo = articleCategoryRepo;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            OperationResult operationResult = new OperationResult();

            if (_articleCategoryRepo.Exists(c => c.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var slug = command.Slug.Slugify();

            var Acategory = new ArticleCategory(command.Name, command.Description, slug,
                command.ShowOrder, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepo.Create(Acategory);
            _articleCategoryRepo.Save();
            return operationResult.Succeeded();


        }

        public OperationResult Edit(EditArticleCategory command)
        {
            OperationResult operationResult = new OperationResult();
            var ACategory = _articleCategoryRepo.Get(command.id);
            if (ACategory == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            if (_articleCategoryRepo.Exists(c => c.Name == command.Name && c.Id != command.id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var slug = command.Slug.Slugify();

            ACategory.Edit(command.Name, command.Description, slug,
                command.ShowOrder, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepo.Save();
            return operationResult.Succeeded();
        }

        public List<ArticleCategoryViewModel> GetArticleCategory()
        {
            return _articleCategoryRepo.GetArticleCategory();
        }

        public EditArticleCategory GetForEdit(long id)
        {
            return _articleCategoryRepo.GetForEdit(id);
        }

        public List<ArticleCategoryViewModel> Seach(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepo.Seach(searchModel);

        }
    }
}
