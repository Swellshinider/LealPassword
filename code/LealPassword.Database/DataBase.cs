using System;
using System.Data.SQLite;
using System.IO;

namespace LealPassword.Database
{
    internal sealed class DataBase : IDisposable
    {
        private readonly SQLiteConnection _connection;

        internal readonly string ACC_TABLE = "TLP_ACCOUNT";
        internal readonly string REG_TABLE = "TLP_REGISTR";
        internal readonly string CRD_TABLE = "TLP_CD_CARD";

        internal DataBase(string directory, string fileName)
        {
            _connection = new SQLiteConnection($"Data Source={directory}\\{fileName}");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists($"{directory}\\{fileName}"))
                File.Create($"{directory}\\{fileName}").Close();

            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.OpenAsync().Wait();

            CreateBaseTable();
        }

        internal SQLiteCommand CreateCommand() => _connection.CreateCommand();

        private void CreateBaseTable()
        {
            using (var command = _connection.CreateCommand())
            {
                var accountTableCmd = $@"CREATE TABLE IF NOT EXISTS {ACC_TABLE} (
                                                'ID'    INTEGER NOT NULL UNIQUE,
                                                'USER'  TEXT NOT NULL,
                                                'PASS'   TEXT NOT NULL,
                                                PRIMARY KEY('ID' AUTOINCREMENT)
                                            )";
                var registrTableCmd = $@"CREATE TABLE IF NOT EXISTS {REG_TABLE} (
	                                            'ID'	INTEGER NOT NULL,
	                                            'NAME'	TEXT NOT NULL,
                                                'TAG'   TEXT NOT NULL,
	                                            'DESC'	TEXT NOT NULL,
	                                            'MAIL'	TEXT NOT NULL,
	                                            'PASS'	TEXT NOT NULL,
                                                'ICON'  TEXT NOT NULL,
	                                            PRIMARY KEY('ID')
                                            )";
                var cardsTableCmd = $@"CREATE TABLE IF NOT EXISTS {CRD_TABLE} (
	                                            'ID'	INTEGER NOT NULL,
	                                            'CARD_NAME'	TEXT NOT NULL,
	                                            'OWNR_NAME'	TEXT NOT NULL,
	                                            'NUMBER'	TEXT NOT NULL,
	                                            'DATE'	INTEGER NOT NULL,
	                                            'SECURITY_NUMBER'	INTEGER NOT NULL,
	                                            PRIMARY KEY('ID')
                                            )";

                command.CommandText = accountTableCmd;
                command.ExecuteNonQueryAsync().Wait();
                command.Reset();

                command.CommandText = registrTableCmd;
                command.ExecuteNonQueryAsync().Wait();
                command.Reset();

                command.CommandText = cardsTableCmd;
                command.ExecuteNonQueryAsync().Wait();
            }
        }

        // TODO: get, save and edit Card, Date is long

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                    _connection.Close();
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