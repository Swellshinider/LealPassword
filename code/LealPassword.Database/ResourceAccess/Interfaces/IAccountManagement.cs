using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.Database.ResourceAccess.Interfaces
{
    internal interface IAccountManagement : IDisposable
    {
        void InsertAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
        List<Account> GetAccount();
    }
}