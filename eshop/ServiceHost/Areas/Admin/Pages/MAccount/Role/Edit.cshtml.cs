using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.MAccount.Role
{
    public class EditModel : PageModel
    {

        public EditRole command;
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }

        [NeedsPermissions(AccountPermissions.EditRole)]

        public void OnGet(long id)
        {

            command = _roleApplication.GetForEdit(id);
            var permissions = new List<PermissionDTO>();
            foreach (var Exposer in _exposers)
            {
                var exposedPermissions = Exposer.Expose();
                foreach (var (Key, Value) in exposedPermissions)
                {
                    permissions.AddRange(Value);
                    var group = new SelectListGroup{ Name = Key};
                    foreach (var Permission in Value)
                    {
                        var item = new SelectListItem(Permission.Name, Permission.Code.ToString())
                        {
                            Group = group

                        };

                        if (command.MappedPermission.Any(c=>c.Code == Permission.Code))                        
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditRole command)
        {
            var Result = _roleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
