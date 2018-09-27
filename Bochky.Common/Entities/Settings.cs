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
        private const string DEFAULT_DBCONNECTION_PATH = @"|DataDirectory|\Database.accdb";
        private const string DEFAULT_DBCONNECTION_PROVIDER = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = ";
        private const string DEFAULT_PATH_TO_SPEC_FOLDER = @"\\fileserver\Bochky\2. Типовые документы\8. CRM\";
        private const string DEFAULT_PATH_TO_CONSUMER_FOLDER = @"\\fileserver\Bochky\1. Клиенты\2. Потенциальные клиенты\";
        private const string DEFAULT_PATH_TO_TEMPLATE_FOLDER = @"\\fileserver\Bochky\1. Клиенты\2. Потенциальные клиенты\1. Шаблон папки\";
        private const string DEFAULT_PATH_TO_CRM_FOLDER = @"\\fileserver\Bochky\2. Типовые документы\8. CRM\";
        private const string DEFAULT_NAME_SPEC_CONSUMER_FOLDER = @"Договор\";

        public string DBConnectionString { get; private set; }
        public string PathToSpecFolder { get; private set; }
        public string PathToConsumerFolder { get; private set; }
        public string PathToTemplateFolder { get; private set; }
        public string PathToCRMFolder { get; private set; }
        public string NameSpecConsumerFolder { get; private set; }

        public Settings()
        {
            DBConnectionString = DEFAULT_DBCONNECTION_PROVIDER + DEFAULT_DBCONNECTION_PATH;
            PathToSpecFolder = DEFAULT_PATH_TO_SPEC_FOLDER;
            PathToConsumerFolder = DEFAULT_PATH_TO_CONSUMER_FOLDER;
            PathToTemplateFolder = DEFAULT_PATH_TO_TEMPLATE_FOLDER;
            PathToCRMFolder = DEFAULT_PATH_TO_CRM_FOLDER;
            NameSpecConsumerFolder = DEFAULT_NAME_SPEC_CONSUMER_FOLDER;
        }
    }
    
}
