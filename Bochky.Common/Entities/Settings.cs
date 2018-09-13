using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает настройки программы
    /// </summary>
    public class Settings
    {
        public string DBConnectionString { get; set; }
        private const string DEFAULT_DBCONNECTION_PATCH = "|DataDirectory|\\Database.accdb";
        private const string DEFAULT_DBCONNECTION_PROVIDER = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = ";

        public Settings()
        {
            DBConnectionString = DEFAULT_DBCONNECTION_PROVIDER + DEFAULT_DBCONNECTION_PATCH;
    }
    }
    
}
