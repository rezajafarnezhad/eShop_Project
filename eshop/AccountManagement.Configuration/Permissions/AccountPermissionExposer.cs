using _0_Framework.Infrastructure;
using AccountManagement.Configuration.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Configuration.Permissions
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {


            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "مدیریت کاربران (MU)",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermissions.ListUser,"لیست کاربران"),
                        new PermissionDTO(AccountPermissions.CrateUser,"ایجاد کاربران"),
                        new PermissionDTO(AccountPermissions.EditUser,"ویرایش کاربران"),
                        new PermissionDTO(AccountPermissions.SearchUser,"جستجو کاربران"),
                        new PermissionDTO(AccountPermissions.PassChangeUser,"تغییر رمز کاربران"),

                    }
                },

                {
                    "مدیریت نقش ها (MRole)",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermissions.ListRoles,"لیست نقش ها"),
                        new PermissionDTO(AccountPermissions.CreateRole,"ایجاد نقش"),
                        new PermissionDTO(AccountPermissions.EditRole,"ویرایش نقش"),

                    }
                },

                {
                    "مشاهده پنل ادمین (Admin)",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermissions.PanelAdmin,"مشاهده پنل ادمین"),
                    }
                },

            };
        }
    }
}
