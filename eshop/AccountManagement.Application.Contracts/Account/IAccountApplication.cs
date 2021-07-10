using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        EditAccount GetForEdit(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        OperationResult ChangePassword(ChangePassword command);

        OperationResult Login(Login command);
        void LogOut();
    }

}
