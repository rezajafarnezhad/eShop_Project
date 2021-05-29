using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class CustomerDiscuntApplication : ICustomerDiscuntApplication
    {
        private readonly ICoustomerDiscountRepo _coustomerDiscountRepo;

        public CustomerDiscuntApplication(ICoustomerDiscountRepo coustomerDiscountRepo)
        {
            _coustomerDiscountRepo = coustomerDiscountRepo;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            OperationResult operationResult = new OperationResult();

            var std = command.StartDate.ToGeorgianDateTime();
            var Etd = command.EndDate.ToGeorgianDateTime();

            var CustomerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, std, Etd, command.Reason);
            _coustomerDiscountRepo.Create(CustomerDiscount);
            _coustomerDiscountRepo.Save();
            return operationResult.Succeeded();


        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            OperationResult operationResult = new OperationResult();
            var customerDiscount = _coustomerDiscountRepo.Get(command.Id);
            if (customerDiscount == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }


            var std = command.StartDate.ToGeorgianDateTime();
            var Etd = command.EndDate.ToGeorgianDateTime();
            customerDiscount.Edit(command.ProductId, command.DiscountRate, std, Etd, command.Reason);
            _coustomerDiscountRepo.Save();
            return operationResult.Succeeded();



        }

        public EditCustomerDiscount GetForEdit(long id)
        {
            return _coustomerDiscountRepo.GetForEdit(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _coustomerDiscountRepo.Search(searchModel);
        }
    }
}
