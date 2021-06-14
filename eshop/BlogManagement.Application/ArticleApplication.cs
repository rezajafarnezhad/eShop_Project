using _0_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepo _articleRepo;
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepo _articleCategoryRepo;
        public ArticleApplication(IArticleRepo articleRepo, IFileUploader fileUploader, IArticleCategoryRepo articleCategoryRepo)
        {
            _articleRepo = articleRepo;
            _fileUploader = fileUploader;
            _articleCategoryRepo = articleCategoryRepo;
        }

        public OperationResult Create(CreateArticle command)
        {
            OperationResult operationResult = new OperationResult();
            if (_articleRepo.Exists(c => c.Title == command.Title))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepo.GetSlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var PicName = _fileUploader.Upload(command.Picture, path);


            var Article = new Article(command.Title, command.ShortDescription, command.Description, PicName
                , command.PictureAlt, command.Title, slug, command.KeyWords,
                command.MetaDescription, command.CanonicalAddress, command.PublishDate.ToGeorgianDateTime(), command.CategoryId);

            _articleRepo.Create(Article);

            _articleRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Edit(EditArticle command)
        {
            OperationResult operationResult = new OperationResult();
            var Article = _articleRepo.GetWithCategory(command.Id);
            if (Article == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);

            }
            if (_articleRepo.Exists(c => c.Title == command.Title && c.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var slug = command.Slug.Slugify();
            var path = $"{Article.ArticleCategory.Slug}/{slug}";
            var PicName = _fileUploader.Upload(command.Picture, path);

            Article.Edit(command.Title,command.ShortDescription,command.Description,PicName,command.PictureAlt,command.PictureTitle,
                slug,command.KeyWords,command.MetaDescription,command.CanonicalAddress,command.PublishDate.ToGeorgianDateTime(),
                command.CategoryId);

            _articleRepo.Save();

            return operationResult.Succeeded();
        }

        public EditArticle GetForEdit(long id)
        {
            return _articleRepo.GetForEdit(id);
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var Article = _articleRepo.Get(id);
            if (Article == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            Article.Remove();
            _articleRepo.Save();
            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var Article = _articleRepo.Get(id);
            if (Article == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            Article.Restore();
            _articleRepo.Save();
            return operationResult.Succeeded();
        }

        public List<ArticleViewModel> Search(ArticleSeachModel seachModel)
        {
            return _articleRepo.Search(seachModel);
        }
    }
}
