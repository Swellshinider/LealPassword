using LealPassword.Database.Entity;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess.Builder
{
    internal static class AccountEntityBuilder
    {
        internal static Account Build(SQLiteDataReader reader)
        {
            if (!reader.HasRows) return new Account();

            var acc = new Account();

            while (reader.Read())
            {
                acc = new Account()
                {
                    Username = (string)reader["USER"],
                    Password = (string)reader["PASS"]
                };
            }

            reader.Close();
            return acc;
        }
    }
}