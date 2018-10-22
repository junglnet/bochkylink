using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;

namespace BochkyLink
{
    static class Program
    {        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>        
        [STAThread]
        public static void Main()
        {
            var assembly = typeof(Program).Assembly;
            var appGuid = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {                    
                    MessageBox.Show("Программа уже запущена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                GC.Collect();

                ISettingLoader binarySettingLoader;
                Settings settings = new Settings();
                binarySettingLoader = new BinarySettingLoader();

                settings = (Settings)binarySettingLoader.LoadSettings(settings.GetPropertyValue("settingsFileName"), settings);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CreateClientSpecForm(settings));
            }
        }
    }
}
