using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepo : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepo
    {
        private readonly DiscountContext _context;
        private readonly DBContext _shopcontext;

        public ColleagueDiscountRepo(DiscountContext context, DBContext shopcontext):base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
        }

        public EditColleagueDiscount GetForEdit(long id)
        {
            var colleagueDiscount = _context.ColleagueDiscounts.Find(id);
            return new EditColleagueDiscount()
            {
                Id = colleagueDiscount.Id,
                DiscountRate = colleagueDiscount.DiscountRate,
                ProductId = colleagueDiscount.ProductId,

            };
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var query = _context.ColleagueDiscounts.Select(c => new ColleagueDiscountViewModel()
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToFarsi(),
                DiscountRate = c.DiscountRate,
                IsRemoved = c.IsRemoved,
                ProductId = c.ProductId

            });
            
            if (searchModel.ProductId > 0 )
            {
                query = query.Where(c => c.ProductId == searchModel.ProductId);
            }

            var Products = _shopcontext.Products.Select(c => new { c.Id, c.Name });

            var Discount = query.OrderByDescending(c => c.Id).ToList();

            Discount.ForEach(d => d.ProductName = Products.FirstOrDefault(c => c.Id == d.ProductId)?.Name);

            return Discount;

        }
    }
}
