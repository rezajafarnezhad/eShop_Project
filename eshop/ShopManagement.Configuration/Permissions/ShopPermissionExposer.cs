using _0_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {


            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "Product",new List<PermissionDTO>
                    {
                        new PermissionDTO(10,"لیست محصولات"),
                        new PermissionDTO(11,"ایجاد محصولات"),
                        new PermissionDTO(12,"ویرایش محصولات"),
                        new PermissionDTO(13,"جستجو محصولات"),

                    }
                },

                {
                    "ProductCategory",new List<PermissionDTO>
                    {
                        new PermissionDTO(14,"لیست گروه محصولات"),
                        new PermissionDTO(15,"ایجاد گروه محصولات"),
                        new PermissionDTO(16,"ویرایش گروه محصولات"),
                        new PermissionDTO(17,"جستجو گروه محصولات"),

                    }
                },

            };
        }
    }
}
