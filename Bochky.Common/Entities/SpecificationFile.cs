using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает файл спецификации
    /// </summary>
    public class SpecificationFile
    {
        public FileInfo FileInf { get; set; }
        public string FullPathToFile { get; private set; }
        public string FolderPath { get; private set; }

        public SpecificationFile (string fullPathToFile)       {
            
            FileInfo fileInf = new FileInfo(fullPathToFile);
            if (fileInf.Exists == false) throw new IOException("Файл " + fullPathToFile + " не найден");
            else
            {
                this.FullPathToFile = fullPathToFile;
                this.FolderPath = fileInf.DirectoryName;
            }
       }        
    }
}

