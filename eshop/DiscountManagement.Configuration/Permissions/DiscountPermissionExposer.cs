using _0_Framework.Infrastructure;
using DiscountManagement.Configuration.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Configuration.Permissions
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {


            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "مدیریت تخفیفات همکاران (DI)",new List<PermissionDTO>
                    {
                        new PermissionDTO(DiscountPermissions.ListDiscount,"لیست تخفیفات همکاران"),
                        new PermissionDTO(DiscountPermissions.DefineDiscount,"ایجاد تخفیفات همکاران"),
                        new PermissionDTO(DiscountPermissions.EditDiscount,"ویرایش تخفیفات همکاران"),
                        new PermissionDTO(DiscountPermissions.SearchDiscount,"جستجو تخفیفات همکاران"),
                        new PermissionDTO(DiscountPermissions.RemoveDiscount,"حذف تخفیفات همکاران"),
                        new PermissionDTO(DiscountPermissions.RestoreDiscount,"بازیابی تخفیفات همکاران"),
                       

                    }
                },
                {
                    "مدیریت تخفیفات مشتریان (DC)",new List<PermissionDTO>
                    {
                        new PermissionDTO(DiscountPermissions.ListCDiscount,"لیست تخفیفات مشتریان"),
                        new PermissionDTO(DiscountPermissions.DefineCDiscount,"ایجاد تخفیفات مشتریان"),
                        new PermissionDTO(DiscountPermissions.EditCDiscount,"ویرایش تخفیفات مشتریان"),
                        new PermissionDTO(DiscountPermissions.SearchCDiscount,"جستجو تخفیفات مشتریان"),


                    }
                },

            };
        }
    }
}
