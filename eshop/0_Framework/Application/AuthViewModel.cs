using System.Collections.Generic;

namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long AccountId { get; set; }
        public long RoleId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<int> Permissions{ get; set; }
        public AuthViewModel(long accountId, long roleId, string fullName, string userName , List<int> permissions)
        {
            AccountId = accountId;
            RoleId = roleId;
            FullName = fullName;
            UserName = userName;
            Permissions = permissions;
        }

        public AuthViewModel()
        {

        }
    }
}