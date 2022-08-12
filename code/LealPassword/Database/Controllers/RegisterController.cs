using LealPassword.Database.Model;
using LealPassword.Database.Logic;
using System.Collections.Generic;

namespace LealPassword.Database.Controllers
{
    internal class RegisterController
    {
        private readonly string _directory;
        private readonly string _fileName;
        private readonly string _masterpassword;

        internal RegisterController(string directory, string fileName, string masterpassword)
        {
            _directory = directory;
            _fileName = fileName;
            _masterpassword = masterpassword;
        }

        internal void UpdateRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using(var logic = new RegisterManagement(_directory, _fileName, _masterpassword))
            {
                logic.UpdateRegister(entity);
            }
        }

        internal void InsertRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using (var logic = new RegisterManagement(_directory, _fileName, _masterpassword))
            {
                logic.InsertRegister(entity);
            }
        }

        internal void DeleteRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using (var logic = new RegisterManagement(_directory, _fileName, _masterpassword))
            {
                logic.DeleteRegister(entity);
            }
        }

        internal List<Register> GetRegisters()
        {
            using (var logic = new RegisterManagement(_directory, _fileName, _masterpassword))
            {
                var entity = logic.GetRegisters();
                return Mapper.Map(entity);
            }
        }
    }
}