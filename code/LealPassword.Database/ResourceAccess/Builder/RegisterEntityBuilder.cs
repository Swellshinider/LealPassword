﻿using LealPassword.Database.Entity;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LealPassword.Database.ResourceAccess.Builder
{
    internal static class RegisterEntityBuilder
    {
        internal static List<Register> Build(SQLiteDataReader reader)
        {
            if (!reader.HasRows) return new List<Register>();

            var regs = new List<Register>();

            while (reader.Read())
            {
                regs.Add(new Register
                {
                    Id = int.Parse(reader["ID"].ToString()),
                    Tag = (string)reader["TAG"],
                    Name = (string)reader["NAME"],
                    Description = (string)reader["DESC"],
                    Email = (string)reader["MAIL"],
                    ImageKey = (string)reader["ICON"] ?? "",
                    Password = (string)reader["PASS"]
                });
            }

            reader.Close();
            return regs;
        }
    }
}