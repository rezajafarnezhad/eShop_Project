using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{


    public class IndexModel : PageModel
    {


    [NeedsPermissions(AccountPermissions.PanelAdmin)]

        public void OnGet()
        {
        }
    }
}
