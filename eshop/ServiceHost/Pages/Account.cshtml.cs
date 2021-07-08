using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {



        }


        [TempData]
        public string Error { get; set; }

        public IActionResult OnPostLogin(Login Command)
        {
            var result = _accountApplication.Login(Command);
            if (result.isSucceeded)
            {
                return RedirectToPage("/Index");

            }

            Error = result.Message;
            return Redirect("/Account");
        }


        public IActionResult OnGetLogOut()
        {
            _accountApplication.LogOut();
            return Redirect("/");
        }

    }
}
