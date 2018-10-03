﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BochkyLink.Common.Entities;

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
            Application.Run(new Form1(settings));
        }
    }
}
