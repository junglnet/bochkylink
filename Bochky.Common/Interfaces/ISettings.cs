using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochkyLink.Common.Interfaces
{
    public interface ISettings
    {
        string DBConnectionString { get;}
        string DBTemplateConnectionString { get; }
        string PathToSpecFolder { get; }
        string PathToConsumerFolder { get; }
        string PathToTemplateFolder { get; }
        string PathToCRMFolder { get; }        
        string NameSpecConsumerFolder { get; }

        void LoadSettigs(ISettingLoader settingLoader);
        void SaveSettigs(ISettingSaver settingSaver);
        void UseDefaults();
    }
}
