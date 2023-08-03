using LealPassword.Database.Logic;
using LealPassword.Database.Model;
using System.Collections.Generic;

namespace LealPassword.Database.Controllers
{
    internal sealed class AccountController : BaseController
    {
        internal AccountController(string directory, string fileName, string unhashedPassword)
            : base(directory, fileName, unhashedPassword) { }

        internal void ClearAccounts()
        {
            using (var logic = new AccountManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.ClearAccounts();
            }
        }

        internal void UpdateAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.UpdateAccount(entity);
            }
        }

        internal void InsertAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.InsertAccount(entity);
            }
        }

        internal void DeleteAccount(Account account)
        {
            var entity = Mapper.Map(account);

            using (var logic = new AccountManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.DeleteAccount(entity);
            }
        }

        internal Account GetAccount(string user)
        {
            var accounts = new List<Account>();

            using (var logic = new AccountManagement(_directory, _fileName, _unhashedPassword))
            {
                var entity = logic.GetAccount();

                foreach (var acc in entity)
                    accounts.Add(Mapper.Map(acc));
            }

            var regController = new RegisterController(_directory, _fileName, _unhashedPassword);
            var regList = regController.GetRegisters();
            var crdController = new CardController(_directory, _fileName, _unhashedPassword);
            var crdList = crdController.GetCards();

            foreach (var acc in accounts)
            {
                if (acc.Username == user)
                {
                    acc.Registers.AddRange(regList);
                    acc.Cards.AddRange(crdList);
                    return acc;
                }
            }

            return null;
        }
    }
}