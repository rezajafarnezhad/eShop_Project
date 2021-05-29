using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CoustomerDiscountRepo : RepositoryBase<long, CustomerDiscount>, ICoustomerDiscountRepo
    {

        private readonly DiscountContext _context;
        private readonly DBContext _shopContext;

        public CoustomerDiscountRepo(DiscountContext context, DBContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetForEdit(long id)
        {
            var CD = _context.CustomerDiscounts.Find(id);

            return new EditCustomerDiscount()
            {
                Id = CD.Id,
                EndDate = CD.EndDate.ToString(CultureInfo.InvariantCulture),
                DiscountRate = CD.DiscountRate,
                StartDate = CD.StartDate.ToString(CultureInfo.InvariantCulture),
                ProductId = CD.ProductId,
                Reason = CD.Reason,

            };

        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {


            var query = _context.CustomerDiscounts.Select(c => new CustomerDiscountViewModel()
            {

                Id = c.Id,
                EndDate = c.EndDate.ToFarsi(),
                StartDate = c.StartDate.ToFarsi(),
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate,
                Reason = c.Reason,
                EnddateGr = c.EndDate,
                StartdateGr = c.StartDate,
                CreationDate = c.CreationDate.ToFarsiFull()

            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                query = query.Where(c => c.StartdateGr <= searchModel.EndDate.ToGeorgianDateTime() &&
                c.EnddateGr >= searchModel.StartDate.ToGeorgianDateTime());
            }

            var Products = _shopContext.Products.Select(c => new { c.Id, c.Name }).ToList();


            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount =>
                discount.ProductName = Products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;
        }
    }
}
