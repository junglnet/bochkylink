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
using BochkyLink.Common.Interfaces;
using BochkyLink.Common.Exception;
using BochkyLink.Source;


namespace BochkyLink
{
    public partial class CreateClientSpecForm : Form, ICreateClientSpecUI
    {
        public ISettings Settings { get; private set; }           
        public ISpecService SpecBusinessLayer { get; private set; }

        public CreateClientSpecForm(Settings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.Settings = settings;

            SpecBusinessLayer = new SpecBusinessLayerImplt(settings);
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Text = "";
                comboBox1.DataSource = SpecBusinessLayer.GetCateriesNameList();              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Text = "";
                comboBox2.DataSource = SpecBusinessLayer.GetModelNameList(comboBox1.Text);                            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SpecBusinessLayer.FillConsumerFolder(comboBox2.Text, textBox1.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void создатьНовуюМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSpecForm newSpecForm = new AddNewSpecForm(Settings);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back) return;
            if ((char)e.KeyChar == (Char)Keys.Space) return;            
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
        }
    }
}
