using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.Database.Logic
{
    public sealed class RegisterManagement : Interfaces.IRegisterManagement
    {
        private readonly ResourceAccess.Interfaces.IRegisterManagement _resource;

        public RegisterManagement(string directory, string fileName)
        {
            _resource = new ResourceAccess.RegisterManagement(directory, fileName);
        }

        public void ClearRegisters()
            => _resource.ClearRegisters();

        public void DeleteRegister(Register register)
            => _resource.DeleteRegister(register);

        public void InsertRegister(Register register)
            => _resource.InsertRegister(register);

        public void UpdateRegister(Register register)
            => _resource.UpdateRegister(register);

        public List<Register> GetRegisters()
            => _resource.GetRegisters();

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