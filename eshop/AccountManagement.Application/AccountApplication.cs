using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {

        private readonly IAccountRepo _accountRepo;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepo _roleRepo;

        public AccountApplication(IAccountRepo accountRepo, IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepo roleRepo)
        {
            _accountRepo = accountRepo;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepo = roleRepo;
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operationResult = new OperationResult();
            if (string.IsNullOrWhiteSpace(command.Mobile)
                ||string.IsNullOrWhiteSpace(command.FullName)
                || string.IsNullOrWhiteSpace(command.Username)
                || string.IsNullOrWhiteSpace(command.Password) 
                || string.IsNullOrWhiteSpace(command.RePassword))
            {
                return operationResult.Failed(ApplicationMessage.RegisterErrorMessage);
            }

            if (_accountRepo.Exists(c => c.Username == command.Username || c.Mobile == command.Mobile))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }
            if (command.Password != command.RePassword)
            {
                return operationResult.Failed(ApplicationMessage.PasswordsNotMatch);
            }

            var path = $"ProfileImage";
            var Picturepath = _fileUploader.Upload(command.ProfilePicture, path);

            var password = PasswordHelper.EncodePasswordMd5(command.Password);

            var Account = new Account(command.FullName, command.Username, command.Mobile,
                password, command.RoleId, Picturepath);

            _accountRepo.Create(Account);
            _accountRepo.Save();
            return operationResult.Succeeded("ثبت نام شما در فروشگاه انجام شد میتواند در فروشگاه لاگین کنید");



        }

        public OperationResult Edit(EditAccount command)
        {
            var operationResult = new OperationResult();
            var Account = _accountRepo.Get(command.Id);
            if (Account ==null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            if (_accountRepo.Exists(c => (c.Username == command.Username || c.Mobile == command.Mobile) && c.Id !=command.Id))
            {
                return operationResult.Failed(ApplicationMessage.duplicated);
            }

            var path = $"ProfileImage";
            var Picturepath = _fileUploader.Upload(command.ProfilePicture, path);

            Account.Edit(command.FullName, command.Username , command.Mobile , command.RoleId , Picturepath);

            _accountRepo.Save();
            return operationResult.Succeeded();

        }

        public EditAccount GetForEdit(long id)
        {
            return _accountRepo.GetForEdit(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepo.Search(searchModel);
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operationResult = new OperationResult();
            var Account = _accountRepo.Get(command.Id);
            if (Account == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            if (command.Password != command.RePassword)
            {
                return operationResult.Failed(ApplicationMessage.PasswordsNotMatch);
            }

            var password = PasswordHelper.EncodePasswordMd5(command.Password);
            Account.ChangePassword(password);
            _accountRepo.Save();
            return operationResult.Succeeded();

        }

        public OperationResult Login(Login command)
        {
            var operationResult = new OperationResult();
            var Account = _accountRepo.GetBy(command.UserName);
            if (Account == null)
            {
                return operationResult.Failed(ApplicationMessage.WrongUserinformation);
            }

            var pass = PasswordHelper.EncodePasswordMd5(command.Password);
            if (pass != Account.Password)
            {
                return operationResult.Failed(ApplicationMessage.WrongUserinformation);
            }

            var permissions = _roleRepo.Get(Account.RoleId).Permissions
                .Select(c=>c.Code).ToList();
            
            var AuthViewModel =new AuthViewModel(Account.Id, Account.RoleId, Account.FullName, Account.Username, permissions);
            _authHelper.SingIn(AuthViewModel);

            return operationResult.Succeeded();

        }

        public void LogOut()
        {
            _authHelper.SingOut();
        }

        public List<AccountViewModel> GetAccount()
        {
            return _accountRepo.GetAccount();
        }
    }
}
