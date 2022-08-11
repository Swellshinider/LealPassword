using LealPassword.Database.Entity;
using System;

namespace LealPassword.Database.Logic.Interfaces
{
    internal interface IAccountManagement : IDisposable
    {
        void InsertAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
        Account GetAccount();
    }
}