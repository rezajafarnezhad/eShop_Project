using _0_Framework.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {

        private readonly IColleagueDiscountRepo _colleagueDiscountRepo;

        public ColleagueDiscountApplication(IColleagueDiscountRepo colleagueDiscountRepo)
        {
            _colleagueDiscountRepo = colleagueDiscountRepo;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            OperationResult operationResult = new OperationResult();

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepo.Create(colleagueDiscount);
            _colleagueDiscountRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            OperationResult operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepo.Get(command.Id);
            if (colleagueDiscount == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepo.Save();
            return operationResult.Succeeded();

        }

        public EditColleagueDiscount GetForEdit(long id)
        {
            return _colleagueDiscountRepo.GetForEdit(id);
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepo.Get(id);
            if (colleagueDiscount == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            colleagueDiscount.Remove();
            _colleagueDiscountRepo.Save();
            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepo.Get(id);
            if (colleagueDiscount == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            colleagueDiscount.Restore();
            _colleagueDiscountRepo.Save();
            return operationResult.Succeeded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepo.Search(searchModel);
        }
    }
}
