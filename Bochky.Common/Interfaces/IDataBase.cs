using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BochkyLink.Common.Interfaces
{
    public interface IDataBase
    {
        DataSet CommonDataSet { get; }
        String ConnectionString { get; }
        bool IsAvaible { get; }

        DataTable GetTable(string tableName);
        DataTable GetTable<T>(string tableName, string selectionKey, T selectionValue);
        void Insert<T>(string tableName, T value);
    }
}
