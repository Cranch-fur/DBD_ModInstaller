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
                BinaryPatcher.Binary patcher = new BinaryPatcher.Binary(filePath);
                var result = await patcher.ReplaceBytes(originalBytes, changedBytes, string.Concat(Enumerable.Repeat('x', originalBytes.Length)), BinaryPatcher.ReplaceMode.FirstMatch) > 0;
                patcher.CloseStream();
                return result;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
