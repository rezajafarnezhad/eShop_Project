using _01_eshopQuery.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Contracts.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ArticleCount { get; set; }
        public List<ArticleQueryModel> Articles { get; set; }

    }
}
