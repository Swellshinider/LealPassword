﻿using LealPassword.Database.Entity;
using LealPassword.Database.ResourceAccess.Builder;
using System;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess
{
    internal sealed class AccountManagement : Interfaces.IAccountManagement
    {
        private readonly string _tableName;
        private readonly DataBase _dataBase;

        internal AccountManagement(string directory, string fileName, string masterPassword)
        {
            _dataBase = new DataBase(directory, fileName, masterPassword);
            _tableName = _dataBase.ACC_TABLE;
        }

        public void DeleteAccount(Account account)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {_tableName} WHERE 
                                            USER = '@user'";

                command.Parameters.AddWithValue("@user", account.Username);
                command.ExecuteNonQuery();
            }
        }

        public void InsertAccount(Account account)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"INSERT INTO {_tableName} ( 
                                            'USER',
                                            'PASS'
                                            )
                                         VALUES ( 
                                            '@user', 
                                            '@pass'
                                            )";

                command.Parameters.AddWithValue("@user", account.Username);
                command.Parameters.AddWithValue("@pass", account.Password);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAccount(Account account)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"UPTADE {_tableName}
                                         SET 
                                            USER = '@user',
                                            PASS = '@pass'
                                         WHERE USER = '@user'
                ";

                command.Parameters.AddWithValue("@user", account.Username);
                command.Parameters.AddWithValue("@pass", account.Password);
                command.ExecuteNonQuery();
            }
        }

        public Account GetAccount()
        {
            SQLiteDataReader reader;

            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"SELECT ID, 
                                                USER, 
                                                PASS
                                        FROM {_tableName} 
                                        ORDER BY 
                                                ID, 
                                                USER,
                                                PASS";

                reader = command.ExecuteReader();
            }

            return AccountEntityBuilder.Build(reader);
        }

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