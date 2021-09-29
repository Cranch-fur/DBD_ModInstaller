﻿using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Dead_By_Daylight_Mod_Installer.Utils
{
    public static class CranchCompressor
    {
        public static string Decompress(string input)
        {
            byte[] compressed = Convert.FromBase64String(input);
            byte[] decompressed = Decompress(compressed);
            return Encoding.UTF8.GetString(decompressed);
        }

        public static string Compress(string input)
        {
            byte[] encoded = Encoding.UTF8.GetBytes(input);
            byte[] compressed = Compress(encoded);
            return Convert.ToBase64String(compressed);
        }

        public static byte[] Decompress(byte[] input)
        {
            using (MemoryStream source = new MemoryStream(input))
            {
                byte[] lengthBytes = new byte[4];
                source.Read(lengthBytes, 0, 4);

                int length = BitConverter.ToInt32(lengthBytes, 0);
                using (GZipStream decompressionStream = new GZipStream(source,
                    CompressionMode.Decompress))
                {
                    byte[] result = new byte[length];
                    decompressionStream.Read(result, 0, length);
                    return result;
                }
            }
        }

        public static byte[] Compress(byte[] input)
        {
            using (MemoryStream result = new MemoryStream())
            {
                byte[] lengthBytes = BitConverter.GetBytes(input.Length);
                result.Write(lengthBytes, 0, 4);

                using (GZipStream compressionStream = new GZipStream(result,
                    CompressionMode.Compress))
                {
                    compressionStream.Write(input, 0, input.Length);
                    compressionStream.Flush();

                }
                return result.ToArray();
            }
        }
    }
}