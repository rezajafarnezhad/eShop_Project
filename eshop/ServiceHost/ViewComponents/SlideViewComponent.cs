using _01_eshopQuery.Contracts.Slide;
using _01_eshopQuery.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {

        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery SlideQuery)
        {
            _slideQuery = SlideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var Model = _slideQuery.GetSlides();
            return View(Model);
        }
    }
}
