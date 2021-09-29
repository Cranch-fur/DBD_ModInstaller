using System.IO;
using System.IO.Compression;

namespace Dead_By_Daylight_Mod_Installer.Utils
{
    public static class GZipCompressor
    {
        public static byte[] Decompress(byte[] input)
        {
            using (MemoryStream resultStream = new MemoryStream())
            using (MemoryStream sourceStream = new MemoryStream(input))
            using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }

        public static byte[] Compress(byte[] input)
        {
            using (MemoryStream resultStream = new MemoryStream())
            using (GZipStream compressionStream = new GZipStream(resultStream, CompressionMode.Compress))
            {
                compressionStream.Write(input, 0, input.Length);
                compressionStream.Close();
                return resultStream.ToArray();
            }
        }
    }
}