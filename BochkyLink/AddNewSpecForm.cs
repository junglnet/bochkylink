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
    /// <summary>
    /// UI создания новой спецификации
    /// </summary>
    public partial class AddNewSpecForm : Form
    {
        ISettings Settings;
        IAddNewSpecService NewSpecService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings"></param>
        public AddNewSpecForm(ISettings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            this.Settings = settings;
            NewSpecService = new NewSpecBusinessLayerImplt (this.Settings);            
        }

        private void AddNewSpecForm_Load(object sender, EventArgs e)
        {            
            try
            {                
                comboBox1.Text = "";
                comboBox1.DataSource = NewSpecService.GetCateriesNameList();
                comboBox2.Text = "";
                comboBox2.DataSource = NewSpecService.GetCateriesNameList();
                label10.Text = "Папка будет создана в папке: " + Settings.GetPropertyValue("PathToCRMFolder");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        /// <summary>
        /// Событие покидание строки модели
        /// </summary>     
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "") textBox3.Text = textBox2.Text;
        }

        /// <summary>
        /// Событие нажатия кнопки содания категории
        /// </summary>  
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

        /// <summary>
        /// Событие нажания кнопки прикрепления файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Событие нажатия кнопки создать
        /// </summary>        
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

        /// <summary>
        /// Событие выбора категории
        /// </summary>
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

        /// <summary>
        /// События нажания кнопки, очистить
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            label8.Text = "Пусто";
        }

        /// <summary>
        /// Событие нажания кнопки закрыть
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
