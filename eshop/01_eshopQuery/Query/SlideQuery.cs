using _01_eshopQuery.Contracts.Slide;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly DBContext _context;

        public SlideQuery(DBContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides.Where(c=>!c.IsRemoved).Select(c => new SlideQueryModel()
            {
                Title = c.Title,
                btnText = c.btnText,
                Heading = c.Heading,
                link = c.Link,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Text = c.Text
            }).ToList();
        }
    }
}
