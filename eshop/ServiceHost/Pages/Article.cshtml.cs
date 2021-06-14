using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {

        private readonly IArticleQuery _articleQuery;

        public ArticleModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public ArticleQueryModel Article { get; set; }
        public List<ArticleQueryModel> LatestArrivalsArticle { get; set; }
        public void OnGet(string id)
        {

            Article = _articleQuery.GetArticleBy(id);
            LatestArrivalsArticle = _articleQuery.GetLatestArrivalsArtticle();
        }
    }
}
