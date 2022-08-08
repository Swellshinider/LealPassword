using System;
using System.Collections.Generic;

namespace LealPassword.DataBase
{
    internal static class IdGenerator
    {
        internal static int Get(List<int> currentIds)
        {
            int id;
            bool newGen;

            do
            {
                id = new Random().Next(1, int.MaxValue);
                newGen = !currentIds.Contains(id);
            } while (newGen);

            return id;
        }
    }
}