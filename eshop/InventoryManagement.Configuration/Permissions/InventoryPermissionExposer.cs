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
                    "Inventory",new List<PermissionDTO>
                    {
                        new PermissionDTO(18,"لیست انبار"),
                        new PermissionDTO(19,"ایجاد انبار"),
                        new PermissionDTO(20,"ویرایش انبار"),
                        new PermissionDTO(21,"جستجو انبار"),

                    }
                }
            };
        }
    }
}
