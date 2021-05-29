using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class SlideRepo : RepositoryBase<long, Slide>, ISlideRepo
    {

        private readonly DBContext _context;

        public SlideRepo(DBContext conetxt) : base(conetxt)
        {
            _context = conetxt;
        }

        public EditSlide GetForEdit(long id)
        {
            var slide = _context.Slides.Find(id);
            return new EditSlide()
            {
                Id = slide.Id,
                Picture = slide.Picture,
                btnText = slide.btnText,
                Heading = slide.Heading,
                PictureAlt = slide.PictureAlt,
                PictureTitle = slide.PictureTitle,
                Text = slide.Text,
                Title = slide.Title,
                link = slide.Link

            };

        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(c => new SlideViewModel()
            {
                Id = c.Id,
                Heading = c.Heading,
                IsRemoved = c.IsRemoved,
                Picture = c.Picture,
                Title = c.Title,
                CreationDate = c.CreationDate.ToFarsi()

            }).OrderByDescending(c=>c.Id).ToList();
        }
    }
}
