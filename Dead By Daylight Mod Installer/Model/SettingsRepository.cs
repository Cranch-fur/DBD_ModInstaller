using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Model
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly string settingsPath;

        public SettingsRepository(string settingsPath)
        {
            this.settingsPath = settingsPath;

            ReadSettingsFromFile();
        }

        public Settings Settings { get; private set; }

        public void SaveSettings()
        {
            File.WriteAllText(this.settingsPath, JsonConvert.SerializeObject(Settings));
        }

        private void ReadSettingsFromFile()
        {
            if (File.Exists(settingsPath))
            {
                Settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(this.settingsPath));
            }
            else
            {
                Settings = new Settings();
            }
        }
    }
}
