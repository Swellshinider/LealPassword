using LealPassword.Database.Logic;
using LealPassword.Database.Model;
using System.Collections.Generic;

namespace LealPassword.Database.Controllers
{
    internal class AccountController
    {
        private readonly string _directory;
        private readonly string _fileName;
        private readonly string _masterpassword;

        internal AccountController(string directory, string fileName, string masterpassword)
        {
            _directory = directory;
            _fileName = fileName;
            _masterpassword = masterpassword;
        }

        internal void UpdateAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                logic.UpdateAccount(entity);
            }
        }

        internal void InsertAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                logic.InsertAccount(entity);
            }
        }

        internal void DeleteAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                logic.DeleteAccount(entity);
            }
        }

        internal Account GetAccount(string user)
        {
            var accounts = new List<Account>();

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                var entity = logic.GetAccount();

                foreach (var acc in entity)
                    accounts.Add(Mapper.Map(acc));
            }

            var _regController = new RegisterController(_directory, _fileName, _masterpassword);
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