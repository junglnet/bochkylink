using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;


namespace BochkyLink.Source
{
    
    public class DataBase
    {
        OleDbConnection CONNECTION;
        String connectionString;
        
        public DataBase(String connectionString)
        {
            this.connectionString = connectionString;
            CONNECTION = new OleDbConnection(connectionString);
            try
            {
                CONNECTION.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           
        }


    }
}
