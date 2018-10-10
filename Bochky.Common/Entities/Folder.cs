using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using BochkyLink.Common.Exception;
using System.Diagnostics;
using System.Threading.Tasks;


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
                this.FolderPath = folderPath;                               
            }
            catch (IOException)
            {
                throw new IOException("Не удалось создать папку " + folderPath);
            }
        }

        public void CreateFolder(bool rewrite)
        {
            if (!rewrite)
                if (Directory.Exists(FolderPath)) throw new IOException("Папка " + FolderPath + " уже существует! Задайте новое имя папки");
            Directory.CreateDirectory(FolderPath);
        }

        /// <summary>
        /// Копирование папки в другую папку
        /// </summary>
        public void CopyDir(string FromDir, string ToDir)
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
            catch (IOException)
            {
                throw;
            }
        }

        /// <summary>
        /// Открытие папки
        /// </summary>
        public void OpenFolder()
        {
            try
            {                
                Task.Run(() => Process.Start("explorer", FolderPath));
            }
            catch (System.Exception)
            {
                throw;
            }
           
        }
    }
   
}
