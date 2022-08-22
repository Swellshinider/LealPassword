using LealPassword.Database.Entity;
using LealPassword.Database.ResourceAccess.Builder;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess
{
    internal sealed class CardManagement : Interfaces.ICardManagement
    {
        private readonly string _tableName;
        private readonly DataBase _dataBase;

        internal CardManagement(string directory, string fileName)
        {
            _dataBase = new DataBase(directory, fileName);
            _tableName = _dataBase.CRD_TABLE;
        }

        public void ClearCards()
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {_tableName}";

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCard(Card card)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"DELETE FROM {_tableName}
                                        WHERE ID = '{card.Id}'";

                command.ExecuteNonQuery();
            }
        }

        public void InsertCard(Card card)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"INSERT INTO {_tableName} (
                                            'CARD_NAME', 
                                            'OWNR_NAME',
                                            'NUMBER', 
                                            'DATE',
                                            'SECURITY_NUMBER'
                                            )
                                         VALUES (
                                            '{card.CardName}', 
                                            '{card.OwnrName}', 
                                            '{card.Number}', 
                                            '{card.DueDate}',
                                            '{card.SecurityNumber}'
                                            )";

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCard(Card card)
        {
            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"UPTADE {_tableName}
                                         SET CARD_NAME = '{card.CardName}',
                                            OWNR_NAME = '{card.OwnrName}',
                                            NUMBER = '{card.Number}',
                                            DATE = '{card.DueDate}',
                                            SECURITY_NUMBER = '{card.SecurityNumber}',
                                         WHERE ID = '{card.Id}'";

                command.ExecuteNonQuery();
            }
        }

        public List<Card> GetCards()
        {
            SQLiteDataReader reader;

            using (var command = _dataBase.CreateCommand())
            {
                command.CommandText = $@"SELECT ID, 
                                                CARD_NAME, 
                                                OWNR_NAME,
                                                NUMBER, 
                                                DATE, 
                                                SECURITY_NUMBER
                                        FROM {_tableName} 
                                        ORDER BY 
                                                ID, 
                                                CARD_NAME, 
                                                OWNR_NAME,
                                                NUMBER, 
                                                DATE, 
                                                SECURITY_NUMBER";

                reader = command.ExecuteReader();
            }

            return CardEntityBuilder.Build(reader);
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
