using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.InfrastructureEFCore.Repository
{
    public class RoleRepo : RepositoryBase<long, Role>, IRoleRepo
    {

        private readonly AccountContext _context;
        public RoleRepo(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<RoleViewModel> list()
        {
            return _context.Roles.Select(c => new RoleViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationDate.ToFarsi()

            }).ToList();
        }

        public EditRole GetForEdit(long id)
        {
            
           var Role =  _context.Roles.Select(c=> new EditRole()
            {
                Id = c.Id,
                Name = c.Name,
                MappedPermission = MapPermissions(c.Permissions)
            }).AsNoTracking().FirstOrDefault(c=>c.Id == id);

            Role.permissions = Role.MappedPermission.Select(c => c.Code).ToList();

            return Role;
        }

        private static List<PermissionDTO> MapPermissions(List<Permission> permissions)
        {
            return permissions.Select(c => new PermissionDTO(c.Code, c.Name)).ToList();
        }
    }
}
