using Dead_By_Daylight_Mod_Installer.Enums;

namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IPickerService
    {
        PickResult PickFilePath(out string filePath, string filter, string initialDirectory = null);
        PickResult PickFolder(out string folderPath);
        PickResult PickSaveFilePath(out string fileName, string filter);
    }
}
