using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Exception;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает папку клиента
    /// </summary>
    public class ConsumerFolder : Folder
    {
        public ConsumerFolder(string basePath, string templateFolderPath, string consumerFolderName) : base(basePath + consumerFolderName)
        {           
            if (consumerFolderName == null || consumerFolderName == "") throw new BusinessException("Не задано имя папки");
            if (consumerFolderName[0] == ' ') throw new BusinessException("Не верное название папки " + consumerFolderName);
            if (consumerFolderName.Length > 50) throw new BusinessException("Слишком длинное название папки");
            else
            {                
                CopyDir(templateFolderPath, this.FolderPath);
            }        
        }

        public ConsumerFolder(string consumerFolderPath, string templateFolderPath) : base(consumerFolderPath)
        {
            if (consumerFolderPath == null || consumerFolderPath == "") throw new BusinessException("Не задано имя папки");
            if (consumerFolderPath[0] == ' ') throw new BusinessException("Не верное название папки " + consumerFolderPath);            
            else
            {
                CopyDir(templateFolderPath, this.FolderPath);
            }
        }

    }
}
