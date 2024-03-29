﻿using LealPassword.Database.Entity;
using LealPassword.Database.ResourceAccess.Builder;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess
{
    internal sealed class RegisterManagement : Interfaces.IRegisterManagement
    {
        private readonly string _tableName;
        private readonly DataBase _dataBase;

        internal RegisterManagement(string directory, string fileName)
        {
            _dataBase = new DataBase(directory, fileName);
            _tableName = _dataBase.REG_TABLE;
        }

        public void ClearRegisters()
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {_tableName}";

                command.ExecuteNonQuery();
            }
        }

        public void DeleteRegister(Register register)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {_tableName} 
                                        WHERE ID = '{register.Id}'";

                command.ExecuteNonQuery();
            }
        }

        public void InsertRegister(Register register)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"INSERT INTO {_tableName} (
                                            'NAME', 
                                            'TAG',
                                            'DESC', 
                                            'MAIL',
                                            'ICON',
                                            'PASS'
                                            )
                                         VALUES (
                                            '{register.Name}', 
                                            '{register.Tag}', 
                                            '{register.Description}', 
                                            '{register.Email}',
                                            '{register.ImageKey}',
                                            '{register.Password}'
                                            )";

                command.ExecuteNonQuery();
            }
        }

        public void UpdateRegister(Register register)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"UPDATE {_tableName}
                                         SET NAME = '{register.Name}',
                                            TAG = '{register.Tag}',
                                            DESC = '{register.Description}',
                                            MAIL = '{register.Email}',
                                            ICON = '{register.ImageKey}',
                                            PASS = '{register.Password}'
                                         WHERE ID = '{register.Id}'";

                command.ExecuteNonQuery();
            }
        }

        public List<Register> GetRegisters()
        {
            SQLiteDataReader reader;

            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"SELECT ID, 
                                                NAME, 
                                                TAG,
                                                DESC, 
                                                MAIL, 
                                                ICON,
                                                PASS
                                        FROM {_tableName} 
                                        ORDER BY 
                                                ID, 
                                                NAME, 
                                                TAG,
                                                DESC, 
                                                MAIL,  
                                                ICON,
                                                PASS";

                reader = command.ExecuteReader();
            }

            return RegisterEntityBuilder.Build(reader);
        }

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
                _dataBase.Dispose();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}