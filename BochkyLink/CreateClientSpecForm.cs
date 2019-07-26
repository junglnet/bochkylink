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
    /// <summary>
    /// UI выбора и создания клиентской спецификации
    /// </summary>
    public partial class CreateClientSpecForm : Form
    {
        ISettings Settings;
        ISpecService SpecBusinessLayer;
        IDBSynchronizer dBSynchronizer;

        /// <summary>
        /// Конструктор
        /// </summary>        
        public CreateClientSpecForm(Settings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Settings = settings;
           
            try
            {
                dBSynchronizer = new FIleDBSynchronizer(Settings.GetPropertyValue("DBTemplateFilePath"), Settings.GetPropertyValue("DBFilePath"));                
                dBSynchronizer.Sync();
               

                SpecBusinessLayer = new SpecBusinessLayerImplt(settings);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        /// <summary>
        /// Событие при выборе категории
        /// </summary>    
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

        /// <summary>
        /// Событие при нажатии на на кнопку формирования
        /// </summary>        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {               
                SpecBusinessLayer.FillConsumerFolder(comboBox2.Text, textBox1.Text, label4.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Событие при нажатии на кнопку закрыть
        /// </summary>        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Событие меню создания новой модели
        /// </summary>   
        private void CreateNewModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewSpecForm newSpecForm = new AddNewSpecForm(Settings);
                newSpecForm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Событие при заполнении строки названия папки
        /// </summary>        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Back) return;
            if ((char)e.KeyChar == (Char)Keys.Space) return;
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
        }

        /// <summary>
        /// Событие меню открыть шаблон
        /// </summary>        
        private void OpenTemplateDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SpecBusinessLayer.OpenTemplateDirectory(comboBox2.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Событие меню изменение параметров
        /// </summary>        
        private void ParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(Settings);
            settingsForm.Show();
        }

        /// <summary>
        /// Событие меню синхронизации БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyncBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dBSynchronizer.Sync();
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = Settings.GetPropertyValue("PathToConsumerFolder");


                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    label4.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}