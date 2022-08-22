using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess.Builder
{
    internal static class CardEntityBuilder
    {
        internal static List<Card> Build(SQLiteDataReader reader)
        {
            if (!reader.HasRows) return new List<Card>();

            var crd = new List<Card>();

            while (reader.Read())
            {
                crd.Add(new Card()
                {
                    Id = int.Parse(reader["ID"].ToString()),
                    CardName = (string)reader["CARD_NAME"],
                    OwnrName = (string)reader["OWNR_NAME"],
                    Number = (string)reader["NUMBER"],
                    DueDate = new DateTime(int.Parse(reader["DATE"].ToString())),
                    SecurityNumber = short.Parse((string)reader["SECURITY_NUMBER"])
                });
            }

            reader.Close();
            return crd;
        }
    }
}