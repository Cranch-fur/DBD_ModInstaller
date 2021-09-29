using Dead_By_Daylight_Mod_Installer.Enums;
using Dead_By_Daylight_Mod_Installer.Model;

namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IPackageService
    {
        ModPackageFormat GetFormat(string filePath);
        ModPackage ReadPackage(string filePath, ModPackageFormat format);
        void SavePackage(string filePath, ModPackage modPackage, ModPackageFormat format);
    }
}
