using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Role;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepo : IRepository<long, Role>
    {
        List<RoleViewModel> list();
        EditRole GetForEdit(long id);
    }
}
