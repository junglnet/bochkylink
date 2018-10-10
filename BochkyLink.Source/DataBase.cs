using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using BochkyLink.Common.Exception;
using BochkyLink.Common.Interfaces;
using BochkyLink.Common.Entities;

namespace BochkyLink.Source
{
    
    public class DataBase : IDataBase
    {
        OleDbConnection CONNECTION;     
        OleDbDataAdapter dataAdapter;
        OleDbCommandBuilder dbBuilder;
        
       // public delegate void DataBaseStateHandler(object sender, CommonEventArgs e);
      //  public event EventHandler UpdateEvent;

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

        /// <summary>
        /// Добавление новой записи в таблицу
        /// </summary>
        /// <typeparam name="T">Тип записи</typeparam>
        /// <param name="tableName"></param>
        /// <param name="value"></param>
        public void Insert<T>(string tableName, T value)
        {
            using (CONNECTION = new OleDbConnection(ConnectionString))
            {
                try
                {
                    CONNECTION.Open();
                    dataAdapter = new OleDbDataAdapter("SELECT * FROM " + tableName + "", CONNECTION);

                    if (!CommonDataSet.Tables.Contains(tableName))                    
                        dataAdapter.Fill(CommonDataSet, tableName);                    

                    CommonDataSet.Tables[tableName].Rows.Add(CommonDataSet.Tables[tableName].Rows.Count + 1, value);
                    
                    Update(tableName, dataAdapter);
                    
                }

                catch (OleDbException ex)
                {
                    throw new DatabaseException("Ошибка взаимодействия с БД:" + "\n" + ex.Message);
                }
            }
        }

        public void Insert<T1, T2>(string tableName, T1 value1, T2 value2)
        {
            using (CONNECTION = new OleDbConnection(ConnectionString))
            {
                try
                {
                    CONNECTION.Open();
                    dataAdapter = new OleDbDataAdapter("SELECT * FROM " + tableName + "", CONNECTION);

                    if (!CommonDataSet.Tables.Contains(tableName))
                        dataAdapter.Fill(CommonDataSet, tableName);

                    CommonDataSet.Tables[tableName].Rows.Add(CommonDataSet.Tables[tableName].Rows.Count + 1, value1, value2);

                    Update(tableName, dataAdapter);
                }

                catch (OleDbException ex)
                {
                    throw new DatabaseException("Ошибка взаимодействия с БД:" + "\n" + ex.Message);
                }
            }
        }

        void Update(string tableName, OleDbDataAdapter dataAdapter)
        {
            dbBuilder = new OleDbCommandBuilder(dataAdapter);

            if (dataAdapter.Update(CommonDataSet, tableName) == 0)
                throw new DatabaseException("База данных не была обновлена!");          
        }
                
    }
}
