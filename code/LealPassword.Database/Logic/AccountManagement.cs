using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LealPassword.Database.Logic
{
    public sealed class AccountManagement : Interfaces.IAccountManagement
    {
        private readonly ResourceAccess.Interfaces.IAccountManagement _resource;
        private readonly string _unhashedPassword;

        public AccountManagement(string directory, string fileName, string unhashedPassword)
        {
            _resource = new ResourceAccess.AccountManagement(directory, fileName);
            _unhashedPassword = unhashedPassword;
        }

        public void ClearAccounts()
            => _resource.ClearAccounts();

        public void DeleteAccount(Account account)
            => _resource.DeleteAccount(account.Encrypt(_unhashedPassword));

        public void InsertAccount(Account account) 
            => _resource.InsertAccount(account.Encrypt(_unhashedPassword));

        public void UpdateAccount(Account account)
            => _resource.UpdateAccount(account.Encrypt(_unhashedPassword));

        public List<Account> GetAccount()
            => _resource.GetAccount().Select(enAcc => enAcc.Decrypt(_unhashedPassword)).ToList();

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