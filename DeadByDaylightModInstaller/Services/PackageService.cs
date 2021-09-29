using Dead_By_Daylight_Mod_Installer.Enums;
using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using Dead_By_Daylight_Mod_Installer.Utils;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Dead_By_Daylight_Mod_Installer.Services
{
    public class PackageService : IPackageService
    {
        public void SavePackage(string filePath, ModPackage modPackage, ModPackageFormat format)
        {
            if (format == ModPackageFormat.Json)
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(modPackage));
            }
            else if (format == ModPackageFormat.CranchJson)
            {
                File.WriteAllText(filePath, CranchCompressor.Compress(JsonConvert.SerializeObject(modPackage)));
            }
            else if (format == ModPackageFormat.GZippedJson)
            {
                string serializedModPackage = JsonConvert.SerializeObject(modPackage);
                byte[] bytes = Encoding.UTF8.GetBytes(serializedModPackage);
                File.WriteAllBytes(filePath, GZipCompressor.Compress(bytes));
            }
            else
            {
                throw new Exception("Unsupported mod package format");
            }
        }

        public ModPackage ReadPackage(string filePath, ModPackageFormat format)
        {
            if (format == ModPackageFormat.Json)
            {
                return JsonConvert.DeserializeObject<ModPackage>(File.ReadAllText(filePath));
            }
            else if (format == ModPackageFormat.CranchJson)
            {
                return JsonConvert.DeserializeObject<ModPackage>(CranchCompressor.Decompress(File.ReadAllText(filePath)));
            }
            else if (format == ModPackageFormat.GZippedJson)
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                byte[] decompressedBytes = GZipCompressor.Decompress(fileBytes);
                return JsonConvert.DeserializeObject<ModPackage>(Encoding.UTF8.GetString(decompressedBytes));
            }
            else
            {
                throw new Exception("Unsupported mod package format");
            }
        }

        public ModPackageFormat GetFormat(string filePath)
        {
            switch (Path.GetExtension(filePath).ToLowerInvariant())
            {
                case ".json":
                    return ModPackageFormat.Json;
                case ".gz":
                    return ModPackageFormat.GZippedJson;
                case ".mjson":
                    return ModPackageFormat.CranchJson;
                default:
                    return ModPackageFormat.Unknown;
            }
        }
    }
}
