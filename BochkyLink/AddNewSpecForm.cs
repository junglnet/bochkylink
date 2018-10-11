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

        public AddNewSpecForm(ISettings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.Settings = settings;
            NewSpecService = new NewSpecBusinessLayerImplt (this.Settings);
            this.Show();
        }

        private void AddNewSpecForm_Load(object sender, EventArgs e)
        {            
            try
            {                
                comboBox1.Text = "";
                comboBox1.DataSource = NewSpecService.GetCateriesNameList();
                comboBox2.Text = "";
                comboBox2.DataSource = NewSpecService.GetCateriesNameList();
                label10.Text = "Папка будет создана в папке: " + Settings.PathToCRMFolder;
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
                comboBox2.DataSource = NewSpecService.GetCateriesNameList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Specification Excel files(*.xlsm)|*.xlsm"
            };
           
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            label8.Text = openFileDialog1.FileName;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NewSpecService.CreateNewSpec(label8.Text, "Пусто", comboBox1.Text, textBox2.Text, comboBox2.Text, comboBox3.Text, textBox3.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox3.Text = "";
                comboBox3.DataSource = NewSpecService.GetModelNameList(comboBox2.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label8.Text = "Пусто";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
