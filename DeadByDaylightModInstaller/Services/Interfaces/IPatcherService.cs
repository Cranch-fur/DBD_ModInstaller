using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IPatcherService
    {
        Task<bool> FindAndReplaceBytes(string filePath, byte[] originalBytes, byte[] changedBytes);
    }
}
