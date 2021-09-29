using System.Collections.Generic;

namespace Dead_By_Daylight_Mod_Installer.Model
{
    public class ModPackage
    {
        public List<Mod> Mods { get; set; }

        public class Mod
        {
            public string Title { get; set; }
            public string PakName { get; set; }
            public byte[] OriginalBytes { get; set; }
            public byte[] ModifiedBytes { get; set; }
        }
    }

}
