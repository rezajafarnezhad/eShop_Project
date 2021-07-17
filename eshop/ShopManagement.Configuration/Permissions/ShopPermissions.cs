using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        public const int ListProducts = 40; 
        public const int CrateProducts = 41; 
        public const int EditProducts = 42; 
        public const int SearchProducts = 43;

        public const int ListProductCategories = 44;
        public const int CrateProductCategories = 45;
        public const int EditProductCategories = 46;
        public const int SearchProductCategpries = 47;

        public const int ListSlides = 48;
        public const int CrateSlider = 49;
        public const int EditSlider = 50;
        public const int RemoveSlide = 51;
        public const int RestoreSlider = 52;

        public const int ListGalleries = 53;
        public const int CrateGallery = 54;
        public const int EditGallery = 55;
        public const int RemoveGalley = 56;
        public const int RestoreGalley = 57;
        public const int searchGalley = 58;
    }
}
