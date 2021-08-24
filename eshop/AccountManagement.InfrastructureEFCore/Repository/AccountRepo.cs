using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.InfrastructureEFCore.Repository
{
    public class AccountRepo : RepositoryBase<long, Account>, IAccountRepo
    {
        private readonly AccountContext _context;
        public AccountRepo(AccountContext context) : base(context)
        {
            _context = context;
        }

        public Account GetBy(string username)
        {
            return _context.Accounts.SingleOrDefault(c => c.Username == username);
        }

        public List<AccountViewModel> GetAccount()
        {
            return _context.Accounts.Select(c => new AccountViewModel()
            {
                Id = c.Id,
                FullName = c.FullName


            }).ToList();

        }

        public EditAccount GetForEdit(long id)
        {
            var c = _context.Accounts.Find(id);

            return new EditAccount()
            {
                Id = c.Id,
                Password = c.Password,
                Mobile = c.Mobile,
                Username = c.Username,
                FullName = c.FullName,
                RoleId = c.RoleId
            };


        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts
                .Include(c=>c.Role)
                .Select(c => new AccountViewModel()
            {
                Id = c.Id,
                Mobile = c.Mobile,
                Username = c.Username,
                FullName = c.FullName,
                ProfilePicture = c.ProfilePicture,
                RoleName = c.Role.Name,
                RoleId = c.RoleId,
                RegisterDate = c.CreationDate.ToFarsi()
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
            {
                query = query.Where(c => c.FullName.Contains(searchModel.FullName));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
            {
                query = query.Where(c => c.Username.Contains(searchModel.UserName));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
            {
                query = query.Where(c => c.Mobile.Contains(searchModel.Mobile));
            }

            if (searchModel.RoleId > 0)
            {
                query = query.Where(c => c.RoleId == searchModel.RoleId);
            }


            return query.ToList();


        }
        

    }
}
