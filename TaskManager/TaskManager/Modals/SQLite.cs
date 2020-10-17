using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaskManager
{
    public class SQLite
    {
        public static string GetDatabasePath(string sqliteFileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            return path;
        }

    }
}
