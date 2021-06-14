using _0_Framework.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepo : IRepository<long, ArticleCategory>
    {
        EditArticleCategory GetForEdit(long id);
        List<ArticleCategoryViewModel> Seach(ArticleCategorySearchModel searchModel);
        string GetSlugBy(long id);
        List<ArticleCategoryViewModel> GetArticleCategory();

    }
}
