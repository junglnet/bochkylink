using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BochkyLink.Common;
using BochkyLink.BL;
using BochkyLink.Common.Entities;
using BochkyLink.Source;


namespace BochkyLink
{
    public partial class Form1 : Form
    {        
        Settings settings;
        DataBase dataBase;

        CategoryList categoryList;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            settings = new Settings();
            dataBase = new DataBase(settings.DBConnectionString);
            
            categoryList = new CategoryList(dataBase);

        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
