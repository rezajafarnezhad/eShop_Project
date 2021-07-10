using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }
        public string ProfilePicture { get; private set; }

        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        public Account(string fullName, string username,
            string mobile, string password, long roleId,
            string profilePicture)
        {
            FullName = fullName;
            Username = username;
            Mobile = mobile;
            Password = password;
            if (roleId == 0)
            {
                RoleId = 3;
            }
            else
            {
                RoleId = roleId;
            }

            ProfilePicture = profilePicture;
        }

        public void Edit(string fullName, string username,
            string mobile, long roleId,
            string profilePicture)
        {
            FullName = fullName;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePicture))
            {
                this.ProfilePicture = profilePicture;

            }
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }

    }
}
