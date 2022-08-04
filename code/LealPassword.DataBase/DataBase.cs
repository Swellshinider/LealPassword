using LealPassword.DataBase.Entity;
using LealPassword.DataBase.ResourceAccess.Builder;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace LealPassword.DataBase
{
    internal sealed class DataBase : IDisposable
    {
        private const string ACC_TABLE = "TLP_ACCOUNT";
        private const string REG_TABLE = "TLP_REGISTR";
        private readonly SQLiteConnection _connection;
        private readonly string _masterpassword;

        internal DataBase(string fileName, string masterpassword)
        {
            _masterpassword = masterpassword;
            _connection = new SQLiteConnection($"Data Source={fileName}");

            if (!File.Exists($"./{fileName}")) 
                SQLiteConnection.CreateFile(fileName);

            CreateBaseTable();
        }

        internal List<Register> GetRegisters()
        {
            Open();
            SQLiteDataReader reader;

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $@"SELECT ID, NAME, DESC, MAIL, PASS
                                        FROM {REG_TABLE} ORDER BY ID, NAME, DESC, MAIL, PASS";
                reader = command.ExecuteReader();
            }
            Close();

            return RegisterEntityBuilder.Build(reader);
        }

        internal void InsertRegister(Register register)
        {
            Open();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $@"INSERT INTO {REG_TABLE} ('ID', 'NAME', 'DESC', 'MAIL', 'PASS')
                                         VALUES ('@id', '@name', '@desc', '@mail', '@pass')";

                command.Parameters.AddWithValue("@id", register.Id);
                command.Parameters.AddWithValue("@name", register.Name);
                command.Parameters.AddWithValue("@desc", register.Description);
                command.Parameters.AddWithValue("@mail", register.Email);
                command.Parameters.AddWithValue("@pass", register.Password);
                command.ExecuteNonQuery();
            }
            Close();
        }
   
        internal void UpdateRegister(Register target)
        {
            Open();
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = $@"UPTADE {REG_TABLE}
                                         SET NAME = '@name',
                                            NAME = '@desc',
                                            NAME = '@mail',
                                            NAME = '@pass'
                                         WHERE ID = '@id'";

                command.Parameters.AddWithValue("@id", target.Id);
                command.Parameters.AddWithValue("@name", target.Name);
                command.Parameters.AddWithValue("@desc", target.Description);
                command.Parameters.AddWithValue("@mail", target.Email);
                command.Parameters.AddWithValue("@pass", target.Password);
                command.ExecuteNonQuery();
            }
            Close();
        }

        internal void DeleteRegister(int id)
        {
            Open();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {REG_TABLE} WHERE ID = '@id'";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            Close();
        }

        #region Private Methods
        private void Open()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.OpenAsync().Wait();
                _connection.SetPassword(_masterpassword);
            }
        }

        private void Close()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
        }

        private void CreateBaseTable()
        {
            Open();

            using (var command = _connection.CreateCommand())
            {
                using (var transaction = command.Transaction)
                {
                    var accountTableCmd = $@"CREATE TABLE IF NOT EXISTS {ACC_TABLE} (
                                                'ID'    INTEGER NOT NULL UNIQUE,
                                                'NAME'  TEXT NOT NULL,
                                                'KEY'   TEXT NOT NULL,
                                                PRIMARY KEY('ID')
                                            );";

                    var registrTableCmd = $@"CREATE TABLE IF NOT EXISTS {REG_TABLE} (
                                                'ID'    INTEGER NOT NULL,
                                                'NAME'  TEXT NOT NULL,
                                                'DESC'  TEXT,
												'MAIL'  TEXT NOT NULL,
												'PASS'  TEXT NOT NULL,
                                                PRIMARY KEY('ID')
                                            );";

                    command.CommandText = accountTableCmd;
                    command.ExecuteNonQueryAsync().Wait();
                    command.Reset();
                    command.CommandText = registrTableCmd;
                    command.ExecuteNonQueryAsync().Wait();
                    transaction.Commit();
                }
            }

            Close();
        }
        #endregion

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection.Dispose();
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