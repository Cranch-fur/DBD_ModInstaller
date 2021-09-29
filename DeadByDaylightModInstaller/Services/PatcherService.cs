using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Services
{
    public class PatchService : IPatcherService
    {
        public async Task<bool> FindAndReplaceBytes(string filePath, byte[] originalBytes, byte[] changedBytes)
        {
            try
            {
                using (BinaryPatcher.Binary patcher = new BinaryPatcher.Binary(filePath))
                {
                    bool result = await patcher.ReplaceBytes(originalBytes, changedBytes, null, BinaryPatcher.ReplaceMode.FirstMatch) > 0;
                    return result;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
