using LealPassword.Database.Model;
using LealPassword.Database.Logic;
using System.Collections.Generic;

namespace LealPassword.Database.Controllers
{
    internal sealed class RegisterController : BaseController
    {
        internal RegisterController(string directory, string fileName, string unhashedPassword)
            : base(directory, fileName, unhashedPassword) { }

        internal void ClearRegisters()
        {
            using (var logic = new RegisterManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.ClearRegisters();
            }
        }

        internal void UpdateRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using(var logic = new RegisterManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.UpdateRegister(entity);
            }
        }

        internal void InsertRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using (var logic = new RegisterManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.InsertRegister(entity);
            }
        }

        internal void DeleteRegister(Register register)
        {
            var entity = Mapper.Map(register);

            using (var logic = new RegisterManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.DeleteRegister(entity);
            }
        }

        internal List<Register> GetRegisters()
        {
            using (var logic = new RegisterManagement(_directory, _fileName, _unhashedPassword))
            {
                var entity = logic.GetRegisters();
                return Mapper.Map(entity);
            }
        }
    }
}