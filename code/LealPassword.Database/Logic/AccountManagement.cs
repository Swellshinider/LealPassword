using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.Database.Logic
{
    public sealed class AccountManagement : Interfaces.IAccountManagement
    {
        private readonly ResourceAccess.Interfaces.IAccountManagement _resource;

        public AccountManagement(string directory, string fileName)
        {
            _resource = new ResourceAccess.AccountManagement(directory, fileName);
        }

        public void ClearAccounts()
            => _resource.ClearAccounts();

        public void DeleteAccount(Account account)
            => _resource.DeleteAccount(account);

        public void InsertAccount(Account account) 
            => _resource.InsertAccount(account);

        public void UpdateAccount(Account account)
            => _resource.UpdateAccount(account);

        public List<Account> GetAccount()
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