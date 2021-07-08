using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contracts.Account
{
    public class CreateAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Username { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Mobile { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Password { get; set; }

        [Range(1, 2000, ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleId { get; set; }
        public IFormFile ProfilePicture { get; set; }

        public List<RoleViewModel> Roles { get; set; }

    }
}
