using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Utils
{
    public static class GZipCompressor
    {
        public static byte[] Decompress(byte[] input)
        {
            using (var resultStream = new MemoryStream())
            using (var sourceStream = new MemoryStream(input))
            using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }

        public static byte[] Compress(byte[] input)
        {
            using (var resultStream = new MemoryStream())
            using (var compressionStream = new GZipStream(resultStream, CompressionMode.Compress))
            {
                compressionStream.Write(input, 0, input.Length);
                compressionStream.Close();
                return resultStream.ToArray();
            }
        }
    }
}