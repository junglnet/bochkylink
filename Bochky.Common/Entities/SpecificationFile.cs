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
       public FileInfo fileInf { get; set; }
       public string fullPathToFile { get; private set; }

       public SpecificationFile (string fullPathToFile)       {
            
            FileInfo fileInf = new FileInfo(fullPathToFile);
            if (fileInf.Exists == false) throw new IOException("Файл " + fullPathToFile + " не найден");
            else
            {
                this.fullPathToFile = fullPathToFile;
            }
       }        
    }
}

