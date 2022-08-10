using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.Database.ResourceLogic.Interfaces
{
    internal interface IRegisterManagement : IDisposable
    {
        void InsertRegister(Register register);
        void UpdateRegister(Register register);
        void DeleteRegister(Register register);
        List<Register> GetRegisters();
    }
}