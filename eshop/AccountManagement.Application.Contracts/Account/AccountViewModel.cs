using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; } 
        public string ProfilePicture { get; set; }
        public string RoleName { get; set; }
        public long RoleId { get; set; }
        public string RegisterDate  { get; set; }
    }
}