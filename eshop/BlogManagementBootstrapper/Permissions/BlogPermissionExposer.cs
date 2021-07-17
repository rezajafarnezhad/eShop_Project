using _0_Framework.Infrastructure;
using BlogManagementBootstrapper.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Configuration.Permissions
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {


            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "مدیریت مقالات (Ar)",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermissions.ListArticle,"لیست مقالات"),
                        new PermissionDTO(BlogPermissions.CrateArticle,"ایجاد مقالات"),
                        new PermissionDTO(BlogPermissions.EditArticle,"ویرایش مقالات"),
                        new PermissionDTO(BlogPermissions.SearchArticle,"جستجو مقالات"),
                        new PermissionDTO(BlogPermissions.Remove,"حدف مقالات"),
                        new PermissionDTO(BlogPermissions.Restore,"بازیابی مقالات"),


                    }
                },
                {
                 "مدیریت دسته بندی مقالات (ArC)",new List<PermissionDTO>
                    {
                        new PermissionDTO(BlogPermissions.ListArticleCategory,"لیست دسته مقالات"),
                        new PermissionDTO(BlogPermissions.CrateArticleCategory,"ایجاد دسته مقالات"),
                        new PermissionDTO(BlogPermissions.EditArticleCategory,"ویرایش دسته مقالات"),
                        new PermissionDTO(BlogPermissions.SearchArticleCategory,"جستجو دسته مقالات"),
                    }
                 }
            };
        }
    }
}
