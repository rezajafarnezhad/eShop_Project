using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        EditColleagueDiscount GetForEdit(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

    }
}
