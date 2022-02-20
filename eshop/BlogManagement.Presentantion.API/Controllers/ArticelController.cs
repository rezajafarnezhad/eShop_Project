using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_eshopQuery.Contracts.Article;

namespace BlogManagement.Presentantion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticelController : ControllerBase
    {
        private readonly IArticleQuery _articleQuery;
        public ArticelController(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        [HttpGet]
        public List<ArticleQueryModel> GetLatestArticle()
        {
            return _articleQuery.GetLatestArrivalsArtticle();
        }
    }
}
