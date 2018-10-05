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
    public class DataBaseAdapter : IDataBaseAdapter
    {
        private const string CATEGORY_TABLE_NAME = "Categories";
        private const string MODEL_TABLE_NAME = "Models";
        private const string SPEC_TABLE_NAME = "Specification";
        private const string CATEGORY_ID_COLUMN = "cat_id";
        private const string CATEGORY_NAME_COLUMN = "cat_name";
        private const string MODEL_ID_COLUMN = "model_id";
        private const string MODEL_NAME_COLUMN = "model_name";
        private const string SPEC_PATH_COLUMN = "spec_path";


        public IDataBase DataBase { get; private set; }

        public DataBaseAdapter(IDataBase db)
        {
            this.DataBase = db;            
        }

        public CategoriesList GetCategoriesList()
        {            
            CategoriesList categoriesList = new CategoriesList();
            DataTable dataTable = DataBase.GetTable(CATEGORY_TABLE_NAME);
           
            foreach (DataRow dtRow in dataTable.Rows)
            {                
                categoriesList.Add(new Category((int)dtRow[CATEGORY_ID_COLUMN], (string)dtRow[CATEGORY_NAME_COLUMN]));
            }
            return categoriesList;
        }        

        public ModelList GetModelListByCategory(Category currentCategory)
        {
            ModelList modelList = new ModelList();
                        
            DataTable dataTable = DataBase.GetTable<int>(MODEL_TABLE_NAME, CATEGORY_ID_COLUMN, currentCategory.ID);
            foreach (DataRow dtRow in dataTable.Rows)
            {                
                    modelList.Add(new Model((int)dtRow[MODEL_ID_COLUMN], (string)dtRow[MODEL_NAME_COLUMN], currentCategory));
            }
            return modelList;
        }       

        public SpecificationFile GetSpecificationFile(Model currentModel, string basePatch)
        {
            SpecificationFile specFile;           
            DataTable dataTable = DataBase.GetTable<int>(SPEC_TABLE_NAME, MODEL_ID_COLUMN, currentModel.ID);            
            if (dataTable.Rows.Count == 1)
            {                    
                specFile = new SpecificationFile(basePatch + (string)(dataTable.Rows[0][SPEC_PATH_COLUMN]));

                return specFile;
            }
            else if(dataTable.Rows.Count == 0) throw new DatabaseException("В таблице " + SPEC_TABLE_NAME + " не найдена запись о файле спецификации.");
            else throw new DatabaseException("Ошибка уникальности ключа в таблице " + SPEC_TABLE_NAME + ". Найдено более чем одна запись.");          
            
        }

        public Category CreateNewCategory(string categoryName)
        {

            DataBase.Insert<string>(CATEGORY_TABLE_NAME, categoryName);

            return new Category(1,"2");
        }

    }
}
