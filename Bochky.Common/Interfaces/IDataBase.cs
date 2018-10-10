using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    public interface IDataBase
    {
        DataSet CommonDataSet { get; }
        String ConnectionString { get; }
        bool IsAvaible { get; }
        //event EventHandler UpdateEvent;

        DataTable GetTable(string tableName);
        DataTable GetTable<T>(string tableName, string selectionKey, T selectionValue);
        void Insert<T>(string tableName, T value);
        void Insert<T1, T2>(string tableName, T1 value1, T2 value2);
    }
}
