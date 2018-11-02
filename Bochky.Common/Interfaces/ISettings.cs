using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// Интерфейс настроек программы
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Списко настроек
        /// </summary>
        List<Property> PropertiesList { get; set; }

        List<Property> NotEditablePropertiesList { get;}

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        /// <param name="dt">Таблица для сохранения</param>
        void SaveSettingsFromSourse(DataTable dt);

        /// <summary>
        /// Сохранение настроек в локальный файл
        /// </summary>
        /// <param name="settingSaver"></param>
        void SaveSettigs(ISettingSaver settingSaver);

        /// <summary>
        /// Загрузка настроек по-умолчанию
        /// </summary>
        void UseDefaults();

        /// <summary>
        /// Получение таблицы настроек
        /// </summary>
        /// <returns>Таблица настроек</returns>
        DataTable GetPropertiesTable();
        
        /// <summary>
        /// Получение значения параметра по имени
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <returns>Значение параметра</returns>
        string GetPropertyValue(string name);
    }
}
