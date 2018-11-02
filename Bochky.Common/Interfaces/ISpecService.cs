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
        void FillConsumerFolder(string model, string consumerFolderName, string priorytyPath);

        /// <summary>
        /// Открывает папку с шаблоном спецификации
        /// </summary>
        /// <param name="model"></param>
        void OpenTemplateDirectory(string model);
    }
}
