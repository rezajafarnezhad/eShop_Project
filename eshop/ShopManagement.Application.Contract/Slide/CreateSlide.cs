using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Slide
{
    public class CreateSlide
    {

        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string btnText { get; set; }
    }
}
