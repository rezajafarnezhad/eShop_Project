
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Role
{
    public class CreateRole
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Name { get; set; }


        public List<int> permissions { get; set; }

    }
}
