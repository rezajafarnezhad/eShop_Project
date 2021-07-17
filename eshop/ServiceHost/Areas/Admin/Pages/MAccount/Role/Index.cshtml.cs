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
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public List<RoleViewModel> roles { get; set; }
        [NeedsPermissions(AccountPermissions.ListRoles)]

        public void OnGet()
        {
            roles = _roleApplication.list();
        }

    }
}
