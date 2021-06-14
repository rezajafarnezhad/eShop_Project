using System.Collections.Generic;

namespace _01_eshopQuery.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryQueryModel> GetArticleCategory();
        ArticleCategoryQueryModel GetArtcleByCategorySlug(string slug);
    }
}
