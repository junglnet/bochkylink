using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using BochkyLink.Common.Exception;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает папку
    /// </summary>
    public abstract class Folder
    {        
        public string FolderPath { get; set; }

        public Folder()
        {

        }

        /// <summary>
        /// Копирование папки в другую папку
        /// </summary>
        protected void CopyDir(string FromDir, string ToDir)
        {                                
                if (Directory.Exists(FromDir))
                {
                    if (Directory.Exists(ToDir) == false) Directory.CreateDirectory(ToDir);
                    foreach (string s1 in Directory.GetFiles(FromDir))
                    {
                        string s2 = ToDir + "\\" + Path.GetFileName(s1);
                        File.Copy(s1, s2);
                    }
                    foreach (string s in Directory.GetDirectories(FromDir))
                    {
                        CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
                    }
                }
                else throw new IOException("Папка шаблона " + FromDir + " не найдена");
            
        }
    }
   
}
