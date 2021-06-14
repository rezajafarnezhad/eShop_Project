using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepo : IRepository<long, Article>
    {
        EditArticle GetForEdit(long id);
        List<ArticleViewModel> Search(ArticleSeachModel seachModel);
        Article GetWithCategory(long id);
    }
}
