using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Model
{
    public class ModListItem
    {
        public class Row
        {
            public const string TitleRowName = "Title";
            public const string PakFileNameRowName = "PakFileName";
            public const string OriginalUbulkPathRowName = "OriginalUbulkPath";
            public const string ModifiedUbulkPathRowName = "ModifiedUbulkPath";
            public ModListItem Parent { get; set; }
            public string DisplayName { get; set; }
            public string Name { get; set; }
            public object Data { get; set; }
        }

        public List<Row> Rows { get; set; }
    }
}
