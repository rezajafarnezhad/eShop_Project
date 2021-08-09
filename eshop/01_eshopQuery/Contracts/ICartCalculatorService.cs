using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Contracts
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }


    public class CartCalculatorService : ICartCalculatorService
    {

        private readonly DiscountContext _discountContext;
        private IAuthHelper _authHelper;

        public CartCalculatorService(DiscountContext discountContext, IAuthHelper authHelper)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();


            var colleagueDiscounts = _discountContext.ColleagueDiscounts.Where(c => !c.IsRemoved)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();

            var CustomerDiscounts = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && c.EndDate > DateTime.Now)
               .Select(c => new { c.ProductId, c.DiscountRate }).ToList();

            var currentAccountRole = _authHelper.CurrentAccountRole();
           

            foreach (var cartitem in cartItems)
            {
                if (currentAccountRole == Roles.colleague)
                {
                    var colleagueDiscount = colleagueDiscounts.FirstOrDefault(c => c.ProductId == cartitem.id);
                    if (colleagueDiscount != null)
                        cartitem.DiscountRate = colleagueDiscount.DiscountRate;
                }
                else
                {
                    var customerDiscount = CustomerDiscounts.FirstOrDefault(c => c.ProductId == cartitem.id);

                    if (customerDiscount != null)
                        cartitem.DiscountRate = customerDiscount.DiscountRate;
                }

                cartitem.DiscountAmout = ((cartitem.TotalItemPrice * cartitem.DiscountRate) / 100);
                cartitem.ItemPayAmount = cartitem.TotalItemPrice - cartitem.DiscountAmout;
                cart.Add(cartitem);
            }

            return cart;
        }
    }


}
