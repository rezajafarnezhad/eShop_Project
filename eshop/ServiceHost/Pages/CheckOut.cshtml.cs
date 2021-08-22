using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_eshopQuery.Contracts;
using _01_eshopQuery.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {

        public Cart Cart;
        const string cartItem = "cart_Item";

        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IOrderApplication _orderApplication;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IAuthHelper _authHelper;
        public CheckOutModel(ICartCalculatorService cartCalculatorService, ICartService cartService, IProductQuery productQuery, IOrderApplication orderApplication, IZarinPalFactory zarinPalFactory, IAuthHelper authHelper)
        {
            _cartCalculatorService = cartCalculatorService;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderApplication = orderApplication;
            _zarinPalFactory = zarinPalFactory;
            _authHelper = authHelper;
            Cart = new Cart();

        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();

            var Value = Request.Cookies[cartItem];

            var cartItems = serializer.Deserialize<List<CartItem>>(Value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice();
            }

            Cart = _cartCalculatorService.ComputeCart(cartItems);
            _cartService.Set(Cart);

        }


        public IActionResult OnPostPay(int paymentMethod)
        {
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);
            var result = _productQuery.CheckInventoryStatus(cart.items);
            if (result.Any(c => !c.IsInStock))
            {
                return RedirectToPage("/Cart");

            }

            var orderId = _orderApplication.PlaceOrder(cart);
            if (paymentMethod == 1)
            {
                var userName = _authHelper.CurrentAccountInfo().UserName;
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(cart.PayAmount.ToString(), "", "", "خرید از درگاه فروشگاه", orderId);

                return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            }
            else
            {
                var paymentResult = new PaymentResult();
                return RedirectToPage(
                    "/PaymentResult", paymentResult.Succeeded("سفارش  نقدی شما با موفقیت انجام شد",null));
            }




        }


        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {

            var orderAmount = _orderApplication.GetAmountBy(oId);
            var verificationResponse =
                _zarinPalFactory.CreateVerificationRequest(authority, orderAmount.ToString(CultureInfo.InvariantCulture));

            var result = new PaymentResult(); ;

            if (status == "OK" && verificationResponse.Status == 100)
            {
                var IssueTrackingNo = _orderApplication.PaymentSucceeded(oId, verificationResponse.RefID);

                Response.Cookies.Delete("cart_Item");

                return RedirectToPage("/PaymentResult",
                    result.Succeeded("با تشکر از خرید شما پرداخت با موفقیت انجام شد", IssueTrackingNo));
            }
            else
            {

                return RedirectToPage("/PaymentResult",
                    result.Failed("پرداخت انجام نشد در صورت کسر وجه از حساب مبلع تا 24 ساعت آینده به حساب شما واریز میشود با تشکر"));
            }




        }



    }
}
