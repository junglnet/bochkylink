using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BochkyLink.BL;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;

namespace BochkyLink
{
    public partial class AddNewSpecForm : Form, IAddNewSpecUI
    {
        public ISettings Settings { get; private set; }

        public IAddNewSpecService NewSpecService { get; private set; }

        public AddNewSpecForm(ISettings settings, IDataBase db)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.Settings = settings;
            NewSpecService = new DataBaseAdapter(this.Settings, db);
            this.Show();
        }

        private void AddNewSpecForm_Load(object sender, EventArgs e)
        {            
            try
            {
                comboBox1.Text = "";
                comboBox1.DataSource = NewSpecService.GetCateriesNameList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "") textBox3.Text = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NewSpecService.CreateNewCategory(textBox1.Text);
                comboBox1.DataSource = NewSpecService.GetCateriesNameList();
                comboBox1.Text = textBox1.Text;
                textBox1.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
