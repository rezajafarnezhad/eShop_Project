using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {

        private readonly IRoleRepo _roleRepo;

        public RoleApplication(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public OperationResult Create(CreateRole command)
        {
            var operationresult = new OperationResult();

            if (_roleRepo.Exists(c=>c.Name == command.Name))
            {
                return operationresult.Failed(ApplicationMessage.duplicated);
            }

            var role = new Role(command.Name);
            _roleRepo.Create(role);
            _roleRepo.Save();
            return operationresult.Succeeded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operationresult = new OperationResult();

            var role = _roleRepo.Get(command.Id);

            if (role == null)
            {
                return operationresult.Failed(ApplicationMessage.recordNotFound);
            }

            if (_roleRepo.Exists(c=>c.Name == command.Name && c.Id !=command.Id))
            {
                return operationresult.Failed(ApplicationMessage.duplicated);
            }

            role.Edit(command.Name);
            _roleRepo.Save();
            return operationresult.Succeeded();

        }

        public List<RoleViewModel> list()
        {
            return _roleRepo.list();
        }

        public EditRole GetForEdit(long id)
        {
            return _roleRepo.GetForEdit(id);
        }
    }
}
