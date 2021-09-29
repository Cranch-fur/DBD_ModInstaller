using System.Collections.Generic;

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
            public string Data { get; set; }
        }

        public List<Row> Rows { get; set; }
    }
}
