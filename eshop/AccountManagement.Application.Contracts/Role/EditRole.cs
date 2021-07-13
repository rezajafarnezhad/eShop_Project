using _0_Framework.Infrastructure;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Role
{
    public class EditRole : CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDTO> MappedPermission { get; set; }

        public EditRole()
        {
            permissions = new List<int>();
        }
    }
}