using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using BochkyLink.Common.Exception;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Source
{
    
    public class DataBase : IDataBase
    {
        OleDbConnection CONNECTION;     
        OleDbDataAdapter dataAdapter;

        public DataSet CommonDataSet { get; private set; }
        public String ConnectionString { get; set; }
        public bool IsAvaible
        {
            get
            {
                if (CONNECTION.State == ConnectionState.Open) return true;
                else return false;
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">Строка подлкючения</param>
        public DataBase(String connectionString)
        {
            CommonDataSet = new DataSet();
            this.ConnectionString = connectionString;                 
        }

        /// <summary>
        /// Получает таблицу из базы данных
        /// </summary>
        /// <param name="tableName">Имя таблицы в базе данных</param>
        /// <returns></returns>
        public DataTable GetTable(string tableName)
        {
            using (CONNECTION = new OleDbConnection(ConnectionString))                
            {
                try
                {
                    CONNECTION.Open();                   
                    DataTable dataTable = new DataTable();
                    dataAdapter = new OleDbDataAdapter("SELECT * FROM " + tableName + "", CONNECTION);
                    if (CommonDataSet.Tables.Contains(tableName)) CommonDataSet.Tables[tableName].Clear();
                    dataAdapter.Fill(CommonDataSet, tableName);
                    dataTable = CommonDataSet.Tables[tableName];

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw new DatabaseException("Ошибка подлючения к базе данных:" + "\n" + ex.Message);
                  
                }                
            }
        }

        /// <summary>
        /// Получает таблицу из базы данных
        /// </summary>
        /// <typeparam name="T">Тип значения ключа</typeparam>
        /// <param name="tableName">Имя таблицы в базе данных</param>
        /// <param name="selectionKey">Ключ отбора в базе</param>
        /// <param name="selectionValue">Значение ключа</param>
        /// <returns></returns>
        public DataTable GetTable<T>(string tableName, string selectionKey, T selectionValue)
        {
            using (CONNECTION = new OleDbConnection(ConnectionString))
            {
                try
                {
                    CONNECTION.Open();
                    DataTable dataTable = new DataTable();
                    dataAdapter = new OleDbDataAdapter("SELECT * FROM " + tableName + " WHERE "
                        + selectionKey + " = " + selectionValue + "", CONNECTION);

                    if (CommonDataSet.Tables.Contains(tableName)) CommonDataSet.Tables[tableName].Clear();

                    dataAdapter.Fill(CommonDataSet, tableName);
                    dataTable = CommonDataSet.Tables[tableName];

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw new DatabaseException("Ошибка подлючения к базе данных:" + "\n" + ex.Message);

                }
            }
        }
        public void Insert<T>(string tableName, T value)
        {
            using (CONNECTION = new OleDbConnection(ConnectionString))
            {
                try
                {
                    CONNECTION.Open();

                    if (!CommonDataSet.Tables.Contains(tableName))                       
                    
                    {
                        dataAdapter = new OleDbDataAdapter("SELECT * FROM " + tableName + "", CONNECTION);                        
                        dataAdapter.Fill(CommonDataSet, tableName);
                    }

                    CommonDataSet.Tables[tableName].Rows.Add(CommonDataSet.Tables[tableName].Rows.Count + 1, value);
                    // Дописать сохранение в базу

                }

                catch (Exception ex)
                {

                    throw new DatabaseException("Ошибка подлючения к базе данных:" + "\n" + ex.Message);
                }
            }
        }
    }
}
