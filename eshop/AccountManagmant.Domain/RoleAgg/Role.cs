using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBase
    {

        public string Name { get; set; }

        public List<Account> Accounts { get; private set; }
        public List<Permission> Permissions { get; private set; }

        public Role(string name , List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
        public void Edit(string name , List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;

        }
        public Role()
        {

        }

    }
}
