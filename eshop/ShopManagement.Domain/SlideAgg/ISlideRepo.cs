using _0_Framework.Domain;
using ShopManagement.Application.Contract.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepo : IRepository<long, Slide>
    {

        EditSlide GetForEdit(long id);
        List<SlideViewModel> GetList();
    }
}
