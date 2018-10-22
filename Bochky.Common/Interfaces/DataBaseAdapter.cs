using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;
using BochkyLink.Common.Exception;


namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс адаптер между BL и database
    /// </summary>
    public abstract class DataBaseAdapter
    {
        /// <summary>
        /// Значения полей БД по-умолчанию
        /// </summary>
        private const string CATEGORY_TABLE_NAME = "Categories";
        private const string MODEL_TABLE_NAME = "Models";
        private const string SPEC_TABLE_NAME = "Specification";
        private const string CATEGORY_ID_COLUMN = "cat_id";
        private const string CATEGORY_NAME_COLUMN = "cat_name";
        private const string MODEL_ID_COLUMN = "model_id";
        private const string MODEL_NAME_COLUMN = "model_name";
        private const string SPEC_PATH_COLUMN = "spec_path";
        protected IDataBase DataBase;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db"></param>
        public DataBaseAdapter(IDataBase db)
        {
            this.DataBase = db;           
        }        

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        protected CategoriesList GetCategoriesList()
        {            
            CategoriesList categoriesList = new CategoriesList();
            DataTable dataTable = DataBase.GetTable(CATEGORY_TABLE_NAME);
           
            foreach (DataRow dtRow in dataTable.Rows)
            {                
                categoriesList.Add(new Category((int)dtRow[CATEGORY_ID_COLUMN], (string)dtRow[CATEGORY_NAME_COLUMN]));
            }
            return categoriesList;
        }      
        
        /// <summary>
        /// Получение списка моделей заданной категории
        /// </summary>
        /// <param name="currentCategory">Списко категорий</param>
        /// <returns></returns>
        protected ModelList GetModelListByCategory(Category currentCategory)
        {
            ModelList modelList = new ModelList();
                        
            DataTable dataTable = DataBase.GetTable<int>(MODEL_TABLE_NAME, CATEGORY_ID_COLUMN, currentCategory.ID);
            
            foreach (DataRow dtRow in dataTable.Rows)
            {                
                    modelList.Add(new Model((int)dtRow[MODEL_ID_COLUMN], (string)dtRow[MODEL_NAME_COLUMN], currentCategory));
            }
            return modelList;
        }       

        /// <summary>
        /// Получение папки со спецификациями заданной модели
        /// </summary>
        /// <param name="currentModel">Модель</param>
        /// <param name="basePatch">Базовый путь</param>
        /// <returns>Файл спецификации</returns>
        protected Folder GetSpecificationFolder(Model currentModel, string basePatch)
        {
            Folder specFolder;

            DataTable dataTable = DataBase.GetTable<int>(SPEC_TABLE_NAME, MODEL_ID_COLUMN, currentModel.ID);

            if (dataTable.Rows.Count == 1)
            {
                specFolder = new Folder(basePatch + (string)(dataTable.Rows[0][SPEC_PATH_COLUMN]));

                return specFolder;
            }
            else if(dataTable.Rows.Count == 0) throw new DatabaseException("В таблице " + SPEC_TABLE_NAME + " не найдена запись о файле спецификации.");
            else throw new DatabaseException("Ошибка уникальности ключа в таблице " + SPEC_TABLE_NAME + ". Найдено более чем одна запись.");                      
        }                

        /// <summary>
        /// Добавление новой категории
        /// </summary>
        /// <param name="categoryName"></param>
        protected void CreateNewCategory(Category newCategory)
        {            
            DataBase.Insert<string>(CATEGORY_TABLE_NAME, newCategory.Name);
        }        

        /// <summary>
        /// Добавление новой модели
        /// </summary>
        /// <param name="category"></param>
        /// <param name="newModelName"></param>
        protected void CreateNewModel(Model newModel)
        {
            DataBase.Insert<string, int>(MODEL_TABLE_NAME, newModel.Name, newModel.Category.ID);
        }

        /// <summary>
        /// Добавление новой спецификации в таблицу 
        /// </summary>
        /// <param name="model_id">ИД модели</param>
        /// <param name="path">короткий путь</param>
        protected void CreateNewSpec(int model_id, string path)
        {
            DataBase.Insert<int, string>(SPEC_TABLE_NAME, model_id, path);
        }
    }
}
