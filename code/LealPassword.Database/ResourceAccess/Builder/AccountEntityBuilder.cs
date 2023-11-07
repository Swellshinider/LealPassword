using LealPassword.Database.Entity;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess.Builder
{
    internal static class AccountEntityBuilder
    {
        internal static List<Account> Build(SQLiteDataReader reader)
        {
            if (!reader.HasRows) return new List<Account>();

            var acc = new List<Account>();

            while (reader.Read())
            {
                acc.Add(new Account()
                {
                    Username = (string)reader["USER"],
                    Password = (string)reader["PASS"]
                });
            }

            reader.Close();
            return acc;
        }
    }
}