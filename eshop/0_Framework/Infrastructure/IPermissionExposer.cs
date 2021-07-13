using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public interface IPermissionExposer
    {

        Dictionary<string, List<PermissionDTO>> Expose();

    }
}
