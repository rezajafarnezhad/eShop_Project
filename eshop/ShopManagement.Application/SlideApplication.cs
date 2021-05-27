using _0_Framework.Application;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepo _slideRepo;

        public SlideApplication(ISlideRepo slideRepo)
        {
            _slideRepo = slideRepo;
        }

        public OperationResult Create(CreateSlide command)
        {
            OperationResult operationResult = new OperationResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text,
                command.link, command.btnText);
            _slideRepo.Create(slide);
            _slideRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Edit(EditSlide command)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepo.Get(command.Id);

            if (slide == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text,
              command.link, command.btnText);

            _slideRepo.Save();
            return operationResult.Succeeded();
        }

        public EditSlide GetForEdit(long id)
        {
            return _slideRepo.GetForEdit(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepo.GetList();
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepo.Get(id);

            if (slide == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            slide.Remove();
            _slideRepo.Save();
            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepo.Get(id);

            if (slide == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            slide.Restore();
            _slideRepo.Save();
            return operationResult.Succeeded();
        }
    }
}
