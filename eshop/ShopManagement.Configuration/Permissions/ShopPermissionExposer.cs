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
                    "مدیریت محصولات (P)",new List<PermissionDTO>
                    {
                        new PermissionDTO(ShopPermissions.ListProducts,"لیست محصولات"),
                        new PermissionDTO(ShopPermissions.CrateProducts,"ایجاد محصولات"),
                        new PermissionDTO(ShopPermissions.EditProducts,"ویرایش محصولات"),
                        new PermissionDTO(ShopPermissions.SearchProducts,"جستجو محصولات"),

                    }
                },

                {
                    " مدیریت گروه محصولات (PC)",new List<PermissionDTO>
                    {
                        new PermissionDTO(ShopPermissions.ListProductCategories,"لیست گروه محصولات"),
                        new PermissionDTO(ShopPermissions.CrateProductCategories,"ایجاد گروه محصولات"),
                        new PermissionDTO(ShopPermissions.EditProductCategories,"ویرایش گروه محصولات"),
                        new PermissionDTO(ShopPermissions.SearchProductCategpries,"جستجو گروه محصولات"),

                    }
                },

                {
                    " مدیریت گالری (Gl)",new List<PermissionDTO>
                    {
                        new PermissionDTO(ShopPermissions.ListGalleries,"لیست گالری محصولات"),
                        new PermissionDTO(ShopPermissions.CrateGallery,"ایجاد گالری محصولات"),
                        new PermissionDTO(ShopPermissions.EditGallery,"ویرایش گالری محصولات"),
                        new PermissionDTO(ShopPermissions.searchGalley,"جستجو گالری محصولات"),
                        new PermissionDTO(ShopPermissions.RemoveGalley,"حذف گالری محصولات"),
                        new PermissionDTO(ShopPermissions.RestoreGalley,"بازیابی گالری محصولات"),

                    }
                },

                {
                    " مدیریت اسلایدر (Sl)",new List<PermissionDTO>
                    {
                        new PermissionDTO(ShopPermissions.ListSlides,"لیست اسلایدر "),
                        new PermissionDTO(ShopPermissions.CrateSlider,"ایجاد اسلایدر"),
                        new PermissionDTO(ShopPermissions.EditSlider,"ویرایش اسلایدر"),
                        new PermissionDTO(ShopPermissions.RemoveSlide,"حذف اسلایدر"),
                        new PermissionDTO(ShopPermissions.RestoreSlider,"بازیابی اسلایدر"),


                    }
                },

            };
        }
    }
}
