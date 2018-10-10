using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// Интерфейс добавления новой спецификации
    /// </summary>
    public interface IAddNewSpecService
    {
        /// <summary>
        /// Общие настройки программы
        /// </summary>
        ISettings Settings { get; }         

        SpecificationFile TemplateSpec { get; }

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
        /// Создание новой категории
        /// </summary>
        /// <param name="newCategoryName">Имя новой категории</param>
        /// <returns></returns>
        void CreateNewCategory(string newCategoryName);

        void CreateNewSpec(string priorityPath, string baseState, string newCategoryName, string newModelName,
            string templateCategoryName, string templateModelName, string newFolderName);

    }
}
