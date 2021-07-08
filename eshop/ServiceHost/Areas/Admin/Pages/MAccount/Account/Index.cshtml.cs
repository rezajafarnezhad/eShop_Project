using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ServiceHost.Areas.Admin.Pages.MAccount.Account
{
    public class IndexModel : PageModel
    {

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public List<AccountViewModel> Account { get; set; }
        public AccountSearchModel SearchModel;
        public SelectList Roles;
        public void OnGet(AccountSearchModel searchModel)
        {

            Account = _accountApplication.Search(searchModel);
            Roles = new SelectList(_roleApplication.list(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var Command = new CreateAccount()
            {
                Roles = _roleApplication.list()

            };
            return Partial("./Create", Command);
        }

        public IActionResult OnPostCreate(CreateAccount Command)
        {
            var result = _accountApplication.Create(Command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Command = _accountApplication.GetForEdit(id);
            Command.Roles = _roleApplication.list();
            return Partial("./Edit", Command);
        }

        public IActionResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var Command = new ChangePassword { Id = id };
            return Partial("./ChangePassword", Command);
        }


        public IActionResult OnPostChangePassword(ChangePassword command)
        {
            var result = _accountApplication.ChangePassword(command);
            return new JsonResult(result);

        }
    }
}
