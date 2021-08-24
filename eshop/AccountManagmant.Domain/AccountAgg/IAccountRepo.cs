using System.Collections.Generic;
using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Domain
{
    public interface IAccountRepo : IRepository<long, Account>
    {
        EditAccount GetForEdit(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        Account GetBy(string username);
        List<AccountViewModel> GetAccount();
    }
}
