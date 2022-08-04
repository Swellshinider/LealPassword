using LealPassword.DataBase.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.DataBase.ResourceAccess.Interface
{
    internal interface IRegisterManagement : IDisposable
    {
        void InsertRegister(Register register);
        void UpdateRegister(Register register);
        void DeleteRegister(Register register);
        List<Register> GetRegisters();
    }
}