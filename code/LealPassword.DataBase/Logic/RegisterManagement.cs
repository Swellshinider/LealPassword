using LealPassword.DataBase.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.DataBase.Logic
{
    public sealed class RegisterManagement : Interface.IRegisterManagement
    {
        private readonly ResourceAccess.Interface.IRegisterManagement _resource;

        public RegisterManagement(string filePath, string masterPassword)
        {
            _resource = new ResourceAccess.RegisterManagement(filePath, masterPassword);
        }

        public void DeleteRegister(Register register)
            => _resource.DeleteRegister(register);

        public List<Register> GetRegisters()
            => _resource.GetRegisters();

        public void InsertRegister(Register register)
            => _resource.InsertRegister(register);

        public void UpdateRegister(Register register)
            => _resource.UpdateRegister(register);

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _resource.Dispose();
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