using LealPassword.Database.Entity;
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

        internal RegisterManagement(string directory, string fileName, string masterPassword)
        {
            _dataBase = new DataBase(directory, fileName, masterPassword);
            _tableName = _dataBase.REG_TABLE;
        }

        public void DeleteRegister(Register register)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {_tableName} 
                                        WHERE 
                                            ID = '@id'";

                command.Parameters.AddWithValue("@id", register.Id);
                command.ExecuteNonQuery();
            }
        }

        public void InsertRegister(Register register)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"INSERT INTO {_tableName} (
                                            'ID', 
                                            'NAME', 
                                            'DESC', 
                                            'MAIL', 
                                            'PASS'
                                            )
                                         VALUES (
                                            '@id', 
                                            '@name', 
                                            '@desc', 
                                            '@mail', 
                                            '@pass'
                                            )";

                command.Parameters.AddWithValue("@id", register.Id);
                command.Parameters.AddWithValue("@name", register.Name);
                command.Parameters.AddWithValue("@desc", register.Description);
                command.Parameters.AddWithValue("@mail", register.Email);
                command.Parameters.AddWithValue("@pass", register.Password);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRegister(Register register)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"UPTADE {_tableName}
                                         SET NAME = '@name',
                                            NAME = '@desc',
                                            NAME = '@mail',
                                            NAME = '@pass'
                                         WHERE ID = '@id'";

                command.Parameters.AddWithValue("@id", register.Id);
                command.Parameters.AddWithValue("@name", register.Name);
                command.Parameters.AddWithValue("@desc", register.Description);
                command.Parameters.AddWithValue("@mail", register.Email);
                command.Parameters.AddWithValue("@pass", register.Password);
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
                                                DESC, 
                                                MAIL, 
                                                PASS
                                        FROM {_tableName} 
                                        ORDER BY 
                                                ID, 
                                                NAME, 
                                                DESC, 
                                                MAIL, 
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