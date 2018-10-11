using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// Интерфес создания клиентской спецификации
    /// </summary>
    public interface ISpecService
    {
        /// <summary>
        /// Общие настройки программы
        /// </summary>
        ISettings Settings { get; }

        /// <summary>
        /// Список категория
        /// </summary>
        CategoriesList CategoriesList { get;}

        /// <summary>
        /// Список моделей
        /// </summary>
        ModelList ModelList { get;}

        /// <summary>
        /// Текущая категория
        /// </summary>
        Category CurrentCategory { get; }

        /// <summary>
        /// Текущая модель
        /// </summary>
        Model CurrentModel { get;}        

        /// <summary>
        /// Формирует список имен категорий в CategoriesList
        /// </summary>
        /// <returns>Список имен категорий</returns>
        List<string> GetCateriesNameList();        

        /// <summary>
        /// Формирует список имен категорий в ModelList по заданной категории
        /// </summary>
        /// <param name="category">Категория</param>
        /// <returns>Список имен категорий</returns>
        List<string> GetModelNameList(string category);

        /// <summary>
        /// Формирование папки клиента 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="consumerFolderName"></param>
        void FillConsumerFolder(string model, string consumerFolderName);

        /// <summary>
        /// Открывает папку с шаблоном спецификации
        /// </summary>
        /// <param name="model"></param>
        void OpenTemplateDirectory(string model);
    }
}
