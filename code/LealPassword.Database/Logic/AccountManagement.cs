using LealPassword.Database.Entity;
using System;

namespace LealPassword.Database.Logic
{
    public sealed class AccountManagement : Interfaces.IAccountManagement
    {
        private readonly ResourceAccess.Interfaces.IAccountManagement _resource;

        public AccountManagement(string directory, string fileName, string masterPassword)
        {
            _resource = new ResourceAccess.AccountManagement(directory, fileName, masterPassword);
        }

        public void DeleteAccount(Account account)
            => _resource.DeleteAccount(account);

        public void InsertAccount(Account account) 
            => _resource.InsertAccount(account);

        public void UpdateAccount(Account account)
            => _resource.UpdateAccount(account);

        public Account GetAccount()
            => _resource.GetAccount();

        #region Dispose
        public void Dispose(bool disposing)
        {
            if (disposing)
                _resource.Dispose();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}