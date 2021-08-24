using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Areas.Admin.Pages.MShop.OrdersM
{
    public class IndexModel : PageModel
    {
        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;
        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
        }

        public List<OrderViewModel> Orders;
        public OrderSearchModel searchModel;
        public SelectList Account;


        public void OnGet(OrderSearchModel SearchModel)
        {

            Orders = _orderApplication.Search(SearchModel);
            Account = new SelectList(_accountApplication.GetAccount(), "Id", "FullName");
        }

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }


        public IActionResult OnGetItems(long id)
        {
            var Items = _orderApplication.GetItems(id);
            return Partial("./Items", Items);
        }


    }
}
