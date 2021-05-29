using _0_Framework.Application;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 1200, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 100, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string StartDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string EndDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }

}
