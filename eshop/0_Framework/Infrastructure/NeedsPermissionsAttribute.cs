using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public class NeedsPermissionsAttribute:Attribute
    {
        public int Permission { get; set; }

        public NeedsPermissionsAttribute(int permission)
        {
            Permission = permission;
        }
    }
}
