using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Entities
{
    public class BinarySettingSaver : ISettingSaver
    {
        public void SaveSettings(ISettings settings, string settingsFileName)
        {
           
            try
            {               
                BinaryFormatter formatter = new BinaryFormatter();             
                using (FileStream fs = new FileStream(settingsFileName, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, settings);                   
                }
            }
            catch (IOException ex)
            {
                throw new IOException("Ошибка при сохранении файла настроек: " + ex);
            }
            
        }
    }
}
