using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using BochkyLink.Common.Exception;
using BochkyLink.Common.Interfaces;
using System.Windows.Forms;


namespace BochkyLink.Source
{
    
    public class DataBase : IDataBase
    {
        //private const string DEFAULT_CATEGORY_TABLE_NAME = "Categories";
        //private const string DEFAULT_MODEL_TABLE_NAME = "Models";
        //private const string DEFAULT_SPEC_TABLE_NAME = "Specification";

        OleDbConnection CONNECTION;
        OleDbDataAdapter dataAdapterCategory;
        OleDbDataAdapter dataAdapterModel;
        OleDbDataAdapter dataAdapterSpec;

        public DataSet CommonDataSet { get; private set; }
        public String ConnectionString { get; set; }   

        public DataBase(String connectionString)
        {
            CommonDataSet = new DataSet();
            this.ConnectionString = connectionString;                 
        }

        public DataTable GetTable(string tableName)
        {
            using (CONNECTION = new OleDbConnection(ConnectionString))                
            {
                try
                {
                    CONNECTION.Open();
                    // MessageBox.Show(tableName);
                    DataTable dataTable = new DataTable();
                    dataAdapterCategory = new OleDbDataAdapter("SELECT * FROM " + tableName + "", CONNECTION);
                    dataAdapterCategory.Fill(CommonDataSet, tableName);
                    dataTable = CommonDataSet.Tables[tableName];

                    return dataTable;
                }
                catch (OleDbException)
                {
                    // событие ошибки
                    return null;
                }

                
            }
        }
        public DataTable GetTable(string tableName, string command)
        {
            return new DataTable();
        }










        ///// <summary>
        ///// Возвращает перечень имен категорий
        ///// </summary> 
        //public List<String> GetCategoriesNameList ()
        //{
        //    List<string> CategoryNameList = new List<string>();

        //        using (CONNECTION = new OleDbConnection(connectionString))
        //        {
        //            try
        //            {
        //                CONNECTION.Open();

        //                dataAdapterCategory = new OleDbDataAdapter("SELECT * FROM " + DEFAULT_CATEGORY_TABLE_NAME + "", CONNECTION);
        //                dataAdapterCategory.Fill(commonDataSet, DEFAULT_CATEGORY_TABLE_NAME);

        //CategoryNameList = commonDataSet.Tables[DEFAULT_CATEGORY_TABLE_NAME].AsEnumerable()
        //                               .Select(r => r.Field<string>("cat_name"))
        //                               .ToList();
        ////            }
        //            catch (Exception)
        //            {


        //            }


        //        }

        //    return CategoryNameList;

        //}

        ///// <summary>
        ///// Возвращает перечень имен моделей для заданной категории
        ///// </summary> 
        //public List<String> GetModelsNameList(string currentCategory)
        //{

        //    int currentCategoryID = 0;
        //    foreach (DataRow dr in commonDataSet.Tables[DEFAULT_CATEGORY_TABLE_NAME].Rows)
        //    {

        //        if (dr["cat_name"].ToString() == currentCategory )
        //        {
        //            currentCategoryID = (int)dr["cat_id"];
        //        }
        //    }

        //    List<string> ModelNameList = new List<string>();

        //    if (commonDataSet.Tables[DEFAULT_MODEL_TABLE_NAME] != null)
        //    {
        //        commonDataSet.Tables[DEFAULT_MODEL_TABLE_NAME].Clear();               
        //    }

        //    using (CONNECTION = new OleDbConnection(connectionString))
        //        {
        //            try
        //            {
        //                CONNECTION.Open();

        //                dataAdapterModel = new OleDbDataAdapter("SELECT * FROM " + DEFAULT_MODEL_TABLE_NAME + " WHERE "
        //            + DEFAULT_MODEL_TABLE_NAME + ".cat_id = " + currentCategoryID + "", CONNECTION);

        //                dataAdapterModel.Fill(commonDataSet, DEFAULT_MODEL_TABLE_NAME);

        //                ModelNameList = commonDataSet.Tables[DEFAULT_MODEL_TABLE_NAME].AsEnumerable()
        //                               .Select(r => r.Field<string>("model_name"))
        //                               .ToList();                   
        //            }
        //            catch (Exception)
        //            {


        //            }


        //        }
        //    return ModelNameList;

        //}
        ///// <summary>
        ///// Возвращает короткий путь до спецификации по выбранной модели
        ///// </summary> 
        //public string GetPatchToSpec(string currentModel)
        //{
        //    int currentModelID = 0;

        //    foreach (DataRow dr in commonDataSet.Tables[DEFAULT_MODEL_TABLE_NAME].Rows)
        //    {

        //        if (dr["model_name"].ToString() == currentModel)
        //        {
        //            currentModelID = (int)dr["model_id"];
        //        }
        //    }            

        //    if (commonDataSet.Tables[DEFAULT_SPEC_TABLE_NAME] != null)
        //    {
        //        commonDataSet.Tables[DEFAULT_SPEC_TABLE_NAME].Clear();
        //    }

        //        using(CONNECTION = new OleDbConnection(connectionString))
        //        {
        //            try
        //            {
        //                CONNECTION.Open();
        //                dataAdapterSpec = new OleDbDataAdapter("SELECT * FROM " + DEFAULT_SPEC_TABLE_NAME + " WHERE "
        //          + DEFAULT_SPEC_TABLE_NAME + ".model_id = " + currentModelID + "", CONNECTION);

        //                dataAdapterSpec.Fill(commonDataSet, DEFAULT_SPEC_TABLE_NAME);
        //                CONNECTION.Close();
        //            }
        //            catch (Exception)
        //            {


        //            }


        //        }


        //    if (commonDataSet.Tables[DEFAULT_SPEC_TABLE_NAME].Rows.Count == 0)
        //        throw new DatabaseException("Не найдена запись для спецификации модели " + currentModel);

        //    else if (commonDataSet.Tables[DEFAULT_SPEC_TABLE_NAME].Rows.Count > 1)
        //        throw new DatabaseException("Найдена более чем одна спецификация по ID " + currentModelID);
        //    else
        //        return commonDataSet.Tables[DEFAULT_SPEC_TABLE_NAME].Rows[0]["spec_path"].ToString();


        //}
    }
}
