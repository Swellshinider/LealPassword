using AutoMapper;
using LealPassword.Database.Logic;
using LealPassword.Database.Model;

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
            var entity = Mapper.Map<Account, Entity.Account>(account);

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                logic.UpdateAccount(entity);
            }
        }

        internal void InsertAccount(Account account)
        {
            var entity = Mapper.Map<Account, Entity.Account>(account);

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                logic.InsertAccount(entity);
            }
        }

        internal void DeleteAccount(Account account)
        {
            var entity = Mapper.Map<Account, Entity.Account>(account);

            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                logic.DeleteAccount(entity);
            }
        }

        internal Account GetAccount()
        {
            using (var logic = new AccountManagement(_directory, _fileName, _masterpassword))
            {
                var entity = logic.GetAccount();
                return Mapper.Map<Entity.Account, Account>(entity);
            }
        }
    }
}