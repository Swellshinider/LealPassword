using LealPassword.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LealPassword.DataBase.ResourceAccess
{
    internal sealed class RegisterManagement : Interface.IRegisterManagement
    {
        private readonly DataBase _dataBase;

        internal RegisterManagement(string filePath, string masterPassword)
        {
            _dataBase = new DataBase(filePath, masterPassword);
        }

        public void DeleteRegister(Register register)
            => _dataBase.DeleteRegister(register.Id);

        public List<Register> GetRegisters()
            => _dataBase.GetRegisters();

        public void InsertRegister(Register register)
            => _dataBase.InsertRegister(register);

        public void UpdateRegister(Register register)
            => _dataBase.UpdateRegister(register);

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataBase.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}