using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Model
{
    public interface ISettingsRepository
    {
        Settings Settings { get; }

        void SaveSettings();
    }
}
