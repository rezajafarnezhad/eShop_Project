using _0_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {


            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "مدیریت انبار (IN)",new List<PermissionDTO>
                    {
                        new PermissionDTO(InventoryPermissions.ListInventory,"لیست انبار"),
                        new PermissionDTO(InventoryPermissions.CrateInventory,"ایجاد انبار"),
                        new PermissionDTO(InventoryPermissions.EditInventory,"ویرایش انبار"),
                        new PermissionDTO(InventoryPermissions.SearchInventory,"جستجو انبار"),
                        new PermissionDTO(InventoryPermissions.Increase,"افرایش موجودی"),
                        new PermissionDTO(InventoryPermissions.Reduce,"کاهش موجودی"),
                        new PermissionDTO(InventoryPermissions.OperationLog,"مشاهده گردش موجودی"),

                    }
                }
            };
        }
    }
}
