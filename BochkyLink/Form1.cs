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
using BochkyLink.Common.Exception;
using BochkyLink.Source;


namespace BochkyLink
{
    public partial class Form1 : Form
    {        
        Settings settings;
        DataBase dataBase;
        
        SpecBusinessLayerImplt specBusinessLayer;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            settings = new Settings();
            dataBase = new DataBase(settings.DBConnectionString);
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            specBusinessLayer = new SpecBusinessLayerImplt(dataBase,settings);

            comboBox1.DataSource = (specBusinessLayer.GetCateriesNameList());
            comboBox1.Text = specBusinessLayer.CategoriesNameList.Count > 0 ? specBusinessLayer.CategoriesNameList[0] : "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            comboBox2.DataSource = (specBusinessLayer.GetModelsNameListByCategory(comboBox1.Text));
            comboBox2.Text = specBusinessLayer.ModelsNameList.Count > 0 ? specBusinessLayer.ModelsNameList[0] : "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                specBusinessLayer.FillConsumerFolder(comboBox2.Text, textBox1.Text);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
