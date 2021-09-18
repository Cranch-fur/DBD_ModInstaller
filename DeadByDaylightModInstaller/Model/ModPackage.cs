using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
