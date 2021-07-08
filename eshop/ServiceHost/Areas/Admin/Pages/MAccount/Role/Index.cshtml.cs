using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.MAccount.Role
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public List<RoleViewModel> roles { get; set; }

        public void OnGet()
        {
            roles = _roleApplication.list();
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateRole();
            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateRole command)
        {
            var Result = _roleApplication.Create(command);
            return new JsonResult(Result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Role = _roleApplication.GetForEdit(id);
            return Partial("./Edit", Role);
        }

        public IActionResult OnPostEdit(EditRole command)
        {
            var Result = _roleApplication.Edit(command);
            return new JsonResult(Result);
        }

    }
}
