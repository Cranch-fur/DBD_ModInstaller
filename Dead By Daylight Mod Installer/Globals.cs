using Microsoft.Win32;

namespace Dead_By_Daylight_Mod_Installer
{
    public static class Globals
    {
        public static string PROGRAM_EXECUTABLE = System.AppDomain.CurrentDomain.FriendlyName;
        public const string REGISTRY_MAIN = @"HKEY_CURRENT_USER\SOFTWARE\DBDModInstaller";

        public static string REGISTRY_VALUE_PAKSFOLDERPATH = REGISTRY_GETVALUE("PaksFolderPath");
        public static string REGISTRY_GETVALUE(string WINREGNAME)
        {
            try
            { return Registry.GetValue(REGISTRY_MAIN, WINREGNAME, "NONE").ToString(); }
            catch { return "NONE"; }
        }
    }
}
