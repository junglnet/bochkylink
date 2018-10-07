using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
   /// <summary>
   /// Интерфейс адаптера между базой данных и бизнесс-логикой получения файла спецификации
   /// </summary>
    public interface IDataBaseAdapter : IAddNewSpecService
    {
        IDataBase DataBase { get;  }
        
        /// <summary>
        /// Формирование списка категорий из БД
        /// </summary>
        /// <returns>Список категорий</returns>
        CategoriesList GetCategoriesList();        

       /// <summary>
       /// Формирование списка моделей из БД, отобранных по категории
       /// </summary>
       /// <param name="currentCategory"></param>
       /// <returns>Список моделей</returns>
        ModelList GetModelListByCategory(Category currentCategory);        

        /// <summary>
        /// Получает файл спецификации из БД и дополняет полным путем к файлу, отбор по модели
        /// </summary>
        /// <param name="currentModel"></param>
        /// <param name="basePatch"></param>
        /// <returns></returns>
        SpecificationFile GetSpecificationFile(Model currentModel, string basePatch);

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <param name="categoryName">Имя категории</param>
        /// <returns></returns>
        void CreateNewCategory(string categoryName);
    }
}
