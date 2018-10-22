using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Interfaces;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// Интерфейс загрузки настроек
    /// </summary>
    public interface ISettingLoader
    {
        ISettings LoadSettings(string settingsFileName, ISettings settings);
    }
}
