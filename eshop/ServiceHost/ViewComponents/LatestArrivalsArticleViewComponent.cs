using _01_eshopQuery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class LatestArrivalsArticleViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArrivalsArticleViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var model = _articleQuery.GetLatestArrivalsArtticle();
            return View(model);
        }
    }
}
