using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BochkyLink.Common.Interfaces;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Загрузка файла настроек из бинарного файла
    /// </summary>
    public class BinarySettingLoader : ISettingLoader
    {
        public ISettings LoadSettings(string settingsFileName, ISettings settings)
        {
           
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {               
                using (FileStream fs = new FileStream(settingsFileName, FileMode.OpenOrCreate))
                {
                    Settings loadedSettings = (Settings)formatter.Deserialize(fs);
                    bool haveNewProperty = false;
                    foreach(Property p in settings.PropertiesList)
                    {
                        int coincidence = 0;
                        foreach (Property pt in loadedSettings.PropertiesList) {                           
                            if (pt.Name == p.Name)
                            {
                                coincidence++;
                            }                            
                        }
                        if(coincidence == 0)
                        {    
                            loadedSettings.PropertiesList.Add(p);
                            haveNewProperty = true;
                        }
                    }

                    if (haveNewProperty)
                    {                        
                        Directory.CreateDirectory(Path.GetDirectoryName(settingsFileName));
                        loadedSettings.SaveSettigs(new BinarySettingSaver());
                    }                   
                    return loadedSettings;
                }
            }
            catch (System.Exception)
            {

                
            }
            Directory.CreateDirectory(Path.GetDirectoryName(settingsFileName));
            settings.SaveSettigs(new BinarySettingSaver());           
            return settings;

        }
    }
}
