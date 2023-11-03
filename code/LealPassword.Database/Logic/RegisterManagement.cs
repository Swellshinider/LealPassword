using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LealPassword.Database.Logic
{
    public sealed class RegisterManagement : Interfaces.IRegisterManagement
    {
        private readonly ResourceAccess.Interfaces.IRegisterManagement _resource;
        private readonly string _unhashedPassword;

        public RegisterManagement(string directory, string fileName, string unhashedPassword)
        {
            _resource = new ResourceAccess.RegisterManagement(directory, fileName);
            _unhashedPassword = unhashedPassword;
        }

        public void ClearRegisters() => _resource.ClearRegisters();

        public void DeleteRegister(Register register) => _resource.DeleteRegister(register.Encrypt(_unhashedPassword));

        public void InsertRegister(Register register) => _resource.InsertRegister(register.Encrypt(_unhashedPassword));

        public void UpdateRegister(Register register) => _resource.UpdateRegister(register.Encrypt(_unhashedPassword));

        public List<Register> GetRegisters() => _resource.GetRegisters().Select(enReg => enReg.Decrypt(_unhashedPassword)).ToList();

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
                _resource.Dispose();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}