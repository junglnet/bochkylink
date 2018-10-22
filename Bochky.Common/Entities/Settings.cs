﻿using System;
using System.Collections.Generic;
using System.Text;
using BochkyLink.Common.Interfaces;
using System.Data;


namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает настройки программы
    /// </summary>
    
    [Serializable]
    public class Settings : ISettings
    {
        private const string DEFAULT_DBCONNECTION_PROVIDER = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = ";
        private const string DEFAULT_PATH_TO_SPEC_FOLDER = @"\\fileserver\Bochky\2. Типовые документы\8. Спецификации\";
        private const string DEFAULT_PATH_TO_CONSUMER_FOLDER = @"\\fileserver\Bochky\1. Клиенты\2. Потенциальные клиенты\";
        private const string DEFAULT_PATH_TO_TEMPLATE_FOLDER = @"\\fileserver\Bochky\1. Клиенты\2. Потенциальные клиенты\1. Шаблон папки\";
        private const string DEFAULT_PATH_TO_CRM_FOLDER = @"\\fileserver\Bochky\2. Типовые документы\8. Спецификации\";
        private const string DEFAULT_NAME_SPEC_CONSUMER_FOLDER = @"\Договор\";
        private const string DEFAULT_DBCONNECTION_PATH = @"\Bochky app\Database.accdb";
        private const string DEFAULT_TEMPLATE_DBCONNECTION_PATH = DEFAULT_PATH_TO_CRM_FOLDER + @"Database.accdb";
        private const string DEFAULT_SETTINGS_FILE_NAME = @"\Bochky app\Settings.dat";

        public List<Property> PropertiesList { get; set; }               
        
        public Settings()
        {
            UseDefaults();            
        }
              
        /// <summary>
        /// Использование настроек по-умолчанию
        /// </summary>
        public void UseDefaults()
        {
            PropertiesList = new List<Property>();            
            PropertiesList.Add(new Property("DBFilePath", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DEFAULT_DBCONNECTION_PATH));
            PropertiesList.Add(new Property("DBTemplateFilePath", DEFAULT_TEMPLATE_DBCONNECTION_PATH));
            PropertiesList.Add(new Property("DBConnectionString", DEFAULT_DBCONNECTION_PROVIDER + GetPropertyValue("DBFilePath")));            
            PropertiesList.Add(new Property("DBTemplateConnectionString", DEFAULT_DBCONNECTION_PROVIDER + DEFAULT_TEMPLATE_DBCONNECTION_PATH));
            PropertiesList.Add(new Property("PathToSpecFolder", DEFAULT_PATH_TO_SPEC_FOLDER));
            PropertiesList.Add(new Property("PathToConsumerFolder", DEFAULT_PATH_TO_CONSUMER_FOLDER));
            PropertiesList.Add(new Property("PathToTemplateFolder", DEFAULT_PATH_TO_TEMPLATE_FOLDER));
            PropertiesList.Add(new Property("PathToCRMFolder", DEFAULT_PATH_TO_CRM_FOLDER));
            PropertiesList.Add(new Property("NameSpecConsumerFolder", DEFAULT_NAME_SPEC_CONSUMER_FOLDER));
            PropertiesList.Add(new Property("settingsFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DEFAULT_SETTINGS_FILE_NAME));
        }

        public DataTable GetPropertiesTable()
        {
            DataTable dt = new DataTable("Properties");
            dt.Columns.Add("Параметр");
            dt.Columns.Add("Значение");
            foreach (Property p in PropertiesList)
            {
                dt.Rows.Add(p.Name, p.Value);
            }
                return dt;
        }

        public string GetPropertyValue(string name)
        {
            foreach (Property p in PropertiesList)
            {
                if (p.Name == name) return p.Value;
            }
            return null;
        }

        /// <summary>
        /// Вызов метода сохранения настроек в файл
        /// </summary>
        /// <param name="settingSaver">Тип сохранения</param>
        public void SaveSettigs(ISettingSaver settingSaver)
        {
            
            settingSaver.SaveSettings(this, GetPropertyValue("settingsFileName"));
        }

        public void SaveSettingsFromSourse(DataTable dt)
        {
            
            PropertiesList = new List<Property>();            
            foreach (DataRow dr in dt.Rows)
            {
                PropertiesList.Add(new Property(dr[0].ToString(),dr[1].ToString()));
                
            }
            
            SaveSettigs(new BinarySettingSaver());
            
        }
    }
    
}
