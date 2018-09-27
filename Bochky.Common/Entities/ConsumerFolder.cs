using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            else
            {                
                CopyDir(templateFolderPath, this.FolderPath);
            }        
        }
       
    }
}
