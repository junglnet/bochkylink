using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BochkyLink.Common.Interfaces;


namespace BochkyLink
{
    /// <summary>
    /// UI редактирования настроек программы
    /// </summary>
    public partial class SettingsForm : Form
    {
        ISettings Settings;
        public SettingsForm(ISettings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Settings = settings;
            this.Text = "Настройки программы. Версия " + ProductVersion;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.RowHeadersVisible = false;
            try
            {
                dataGridView1.DataSource = Settings.GetPropertiesTable();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                      
        }

        /// <summary>
        /// Событие нажания кнопки сохранить
        /// </summary>    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.SaveSettingsFromSourse((DataTable)dataGridView1.DataSource);
                Application.Restart();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }        
    }
}
