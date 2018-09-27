using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using BochkyLink.Common.Exception;
using System.Windows.Forms;
using System.Diagnostics;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает папку
    /// </summary>
    public class Folder
    {        
        public string FolderPath { get; set; }

        public Folder(string folderPath)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(folderPath);
                this.FolderPath = folderPath + "\\";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Копирование папки в другую папку
        /// </summary>
        protected static void CopyDir(string FromDir, string ToDir)
        {                                
                if (!Directory.Exists(FromDir)) throw new IOException("Папка " + FromDir + " не найдена");
                if (!Directory.Exists(ToDir)) Directory.CreateDirectory(ToDir);
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

        /// <summary>
        /// Копирование файла в папку
        /// </summary>
        public void PutFileToFolder(string pathToFile)
        {            
            try
            {
                FileInfo file = new FileInfo(pathToFile);
                if (!Directory.Exists(FolderPath)) throw new IOException("Папка назначения " + FolderPath + " не найдена!");
                if (!file.Exists) throw new IOException("файл " + file.FullName + " не найден!");
                file.CopyTo(FolderPath + "\\" + file.Name, false);

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Открытие папки
        /// </summary>
        public void OpenFolder()
        {
            try
            {
                // полная хрень
                //Process.Start(FolderPath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
   
}
