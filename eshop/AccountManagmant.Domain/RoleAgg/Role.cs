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

        public List<Account> Accounts { get;private set; }

        public Role(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            Name = name;
        }
       
    }
}
