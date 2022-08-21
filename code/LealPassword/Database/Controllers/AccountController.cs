using LealPassword.Database.Logic;
using LealPassword.Database.Model;
using System.Collections.Generic;

namespace LealPassword.Database.Controllers
{
    internal class AccountController
    {
        private readonly string _directory;
        private readonly string _fileName;

        internal AccountController(string directory, string fileName)
        {
            _directory = directory;
            _fileName = fileName;
        }

        internal void ClearAccounts()
        {
            using (var logic = new AccountManagement(_directory, _fileName))
            {
                logic.ClearAccounts();
            }
        }

        internal void UpdateAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName))
            {
                logic.UpdateAccount(entity);
            }
        }

        internal void InsertAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName))
            {
                logic.InsertAccount(entity);
            }
        }

        internal void DeleteAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName))
            {
                logic.DeleteAccount(entity);
            }
        }

        internal Account GetAccount(string user)
        {
            var accounts = new List<Account>();

            using (var logic = new AccountManagement(_directory, _fileName))
            {
                var entity = logic.GetAccount();

                foreach (var acc in entity)
                    accounts.Add(Mapper.Map(acc));
            }

            var _regController = new RegisterController(_directory, _fileName);
            var regList = _regController.GetRegisters();

            foreach (var acc in accounts)
            {
                if (acc.Username == user)
                {
                    acc.Registers.AddRange(regList);
                    return acc;
                }
            }

            return null;
        }
    }
}