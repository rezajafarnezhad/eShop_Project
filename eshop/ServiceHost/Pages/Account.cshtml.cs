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
        public string LoginMessage { get; set; }

        public IActionResult OnPostLogin(Login Command)
        {
            var result = _accountApplication.Login(Command);
            if (result.isSucceeded)
            {
                return RedirectToPage("/Index");

            }

            LoginMessage = result.Message;
            return Redirect("/Account");
        }


        [TempData]
        public string RegisterMessage { get; set; }

        [TempData]
        public string SuccessRegister { get; set; }
        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            if (result.isSucceeded)
            {
                SuccessRegister = result.Message;
                return RedirectToPage("/Account");

            }
            RegisterMessage = result.Message;
            return Redirect("/Account");
        }



        public IActionResult OnGetLogOut()
        {
            _accountApplication.LogOut();
            return Redirect("/");
        }

    }
}
