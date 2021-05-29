using _0_Framework.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using System.Collections.Generic;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepo : IRepository<long, ColleagueDiscount>
    {

        EditColleagueDiscount GetForEdit(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

    }
}
