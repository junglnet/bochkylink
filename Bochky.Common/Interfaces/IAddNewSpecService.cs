using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Interfaces
{
   public interface IAddNewSpecService
    {
        /// <summary>
        /// Общие настройки программы
        /// </summary>
        ISettings Settings { get; }
              

        /// <summary>
        /// Список категория
        /// </summary>
        CategoriesList CategoriesList { get; }

        /// <summary>
        /// Список моделей
        /// </summary>
        ModelList ModelList { get; }

        /// <summary>
        /// Текущая категория
        /// </summary>
        Category CurrentCategory { get; }

        /// <summary>
        /// Текущая модель
        /// </summary>
        Model CurrentModel { get; }

        /// <summary>
        /// Формирует список имен категорий в CategoriesList
        /// </summary>
        /// <returns>Список имен категорий</returns>
        List<string> GetCateriesNameList();

        SpecificationFile TemplateSpec { get; }

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

        /// <summary>
        /// Создать новую модель
        /// </summary>
        /// <param name="category"></param>
        /// <param name="newModelName"></param>
        void CreateNewModel(Category category, string newModelName);

        /// <summary>
        /// Создание новой спецификации
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="path"></param>
        void CreateNewSpec(SpecificationFile sFile, string path);

    }
}
