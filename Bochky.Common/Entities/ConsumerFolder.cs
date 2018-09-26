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
        public ConsumerFolder(string basePath, string templateFolderPath, string consumerFolderName)
        {
            if (consumerFolderName == null || consumerFolderName == "") throw new BusinessException("Не задано имя папки");
            else
            {
                this.FolderPath = basePath + consumerFolderName;
                CopyDir(templateFolderPath, this.FolderPath);
            }
                       
        }
    }
}
