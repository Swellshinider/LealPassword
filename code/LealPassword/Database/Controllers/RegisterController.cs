using LealPassword.Database.Model;
using LealPassword.Database.Logic;
using System.Collections.Generic;
using Register = LealPassword.Database.Model.Register;

namespace LealPassword.Database.Controllers
{
    internal class RegisterController
    {
        private readonly string _directory;
        private readonly string _fileName;

        internal RegisterController(string directory, string fileName)
        {
            _directory = directory;
            _fileName = fileName;
        }

        internal void ClearRegisters()
        {
            using (var logic = new RegisterManagement(_directory, _fileName))
            {
                logic.ClearRegisters();
            }
        }

        internal void UpdateRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using(var logic = new RegisterManagement(_directory, _fileName))
            {
                logic.UpdateRegister(entity);
            }
        }

        internal void InsertRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using (var logic = new RegisterManagement(_directory, _fileName))
            {
                logic.InsertRegister(entity);
            }
        }

        internal void DeleteRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using (var logic = new RegisterManagement(_directory, _fileName))
            {
                logic.DeleteRegister(entity);
            }
        }

        internal List<Register> GetRegisters()
        {
            using (var logic = new RegisterManagement(_directory, _fileName))
            {
                var entity = logic.GetRegisters();
                return Mapper.Map(entity);
            }
        }
    }
}