using AutoMapper;
using LealPassword.DataBase.Logic;
using LealPassword.DataBase.Model;

namespace LealPassword.DataBase.Controller
{
    internal class RegisterController
    {
        private readonly string _filepath;
        private readonly string _masterpassword;

        internal RegisterController(string filepath, string masterpassword)
        {
            _filepath = filepath;
            _masterpassword = masterpassword;
        }

        internal void UpdateRegister(Register register)
        {
            var entity = Mapper.Map<Register, Entity.Register> (register);

            using var logic = new RegisterManagement(_filepath, _masterpassword);
            logic.UpdateRegister(entity);
        }

        internal void InsertRegister(Register register)
        {
            var entity = Mapper.Map<Register, Entity.Register>(register);

            using var logic = new RegisterManagement(_filepath, _masterpassword);
            logic.InsertRegister(entity);
        }

        internal void DeleteRegister(Register register)
        {
            var entity = Mapper.Map<Register, Entity.Register>(register);

            using var logic = new RegisterManagement(_filepath, _masterpassword);
            logic.DeleteRegister(entity);
        }

        internal List<Register> GetRegisters()
        {
            using var logic = new RegisterManagement(_filepath, _masterpassword);
            var entity = logic.GetRegisters();

            return Mapper.Map<List<Entity.Register>, List<Register>>(entity);
        }
    }
}
