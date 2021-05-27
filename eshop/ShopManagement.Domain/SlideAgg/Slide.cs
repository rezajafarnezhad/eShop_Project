using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {

        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }

        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string Link { get;private set; }
        public string btnText { get; private set; }
        public bool IsRemoved { get; private set; }

        public Slide(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string link , string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            Link = link;
            this.btnText = btnText;
        }


        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string link, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            Link = link;
            this.btnText = btnText;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;

        }
    }
}
