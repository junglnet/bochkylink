using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BochkyLink.Common.Entities;
using BochkyLink.Source;

namespace BochkyLink
{
    static class Program
    {        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>        
        [STAThread]
        static void Main()
        {
            Settings settings = new Settings();
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new CreateClientSpecForm(settings));
            Application.Run(new AddNewSpecForm(settings));
        }
    }
}
