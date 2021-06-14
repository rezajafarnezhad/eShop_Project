using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Article;
using _01_eshopQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly IArticleQuery _articleQuery;

        public ArticleCategoryModel(IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _articleQuery = articleQuery;
        }

        public ArticleCategoryQueryModel ArticleCategory { get; set; }
        public List<ArticleQueryModel> LatestArrivalsArticle { get; set; }


        public void OnGet(string id)
        {

            ArticleCategory = _articleCategoryQuery.GetArtcleByCategorySlug(id);
            LatestArrivalsArticle = _articleQuery.GetLatestArrivalsArtticle();
        }
    }
}
