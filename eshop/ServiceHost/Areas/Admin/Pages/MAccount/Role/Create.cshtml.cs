using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.MAccount.Role
{
    public class CreateModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public CreateModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public CreateRole command;

        [NeedsPermissions(AccountPermissions.CreateRole)]

        public void OnGet()
        {
        }
        public IActionResult OnPost(CreateRole command)
        {
            var Result = _roleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
