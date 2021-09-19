using Dead_By_Daylight_Mod_Installer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IPickerService
    {
        PickResult PickFilePath(out string filePath, string filter);
        PickResult PickFolder(out string folderPath);
        PickResult PickSaveFilePath(out string fileName);
    }
}
