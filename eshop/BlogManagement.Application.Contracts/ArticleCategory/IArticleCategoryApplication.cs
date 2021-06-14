using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {

        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetForEdit(long id);
        List<ArticleCategoryViewModel> Seach(ArticleCategorySearchModel searchModel);
        List<ArticleCategoryViewModel> GetArticleCategory();

    }
}
