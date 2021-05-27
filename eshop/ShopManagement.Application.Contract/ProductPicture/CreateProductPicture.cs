using _0_Framework.Application;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,100000,ErrorMessage =ValidationMessages.IsRequired)]
        public long ProductId { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string PictureName { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureTitle { get;  set; }
        public List<ProductViewModel> Products { get; set; }
    }

}
