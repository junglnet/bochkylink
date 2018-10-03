using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;
using BochkyLink.Common.Exception;
using System.Windows.Forms;

namespace BochkyLink.Common.Entities
{
    public class DataBaseAdapter : IDataBaseAdapter
    {
        private const string CATEGORY_TABLE_NAME = "Categories";
        private const string MODEL_TABLE_NAME = "Models";
        private const string SPEC_TABLE_NAME = "Specification";
        private const string CATEGORY_ID_COLUMN = "cat_id";
        private const string CATEGORY_NAME_COLUMN = "cat_name";


        public IDataBase db { get; set; }

        public DataBaseAdapter(IDataBase db)
        {
            this.db = db;
            
        }

        public CategoriesList GetCategoriesListFromDataSet()
        {            
            if (db == null) throw new DatabaseException("База данных пуста");

            CategoriesList categoriesList = new CategoriesList();
            DataTable dataTable = db.GetTable(CATEGORY_TABLE_NAME);

            foreach (DataRow dtRow in dataTable.Rows)
            {                
                categoriesList.addCategory(new Category((int)dtRow[CATEGORY_ID_COLUMN], (string)dtRow[CATEGORY_NAME_COLUMN]));
            }
            return categoriesList;
        }


        public List<Model> GetModelListByCategory(Category currentCanegory)
        {
            return new List<Model>();
        }
        public SpecificationFile GetSpecificationFile(Model currentModel)
        {
            return new SpecificationFile("");
        }
    }
}
