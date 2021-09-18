using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var installerView = new InstallerForm();
            //var installerView = new CreatorForm();
            var settingsRepository = new SettingsRepository(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json"));
            var messageBoxService = new MessageBoxService();
            var pickerService = new PickerService();
            var patcherService = new PatchService();

            var installerPresenter = new InstallerPresenter(installerView, settingsRepository, messageBoxService, pickerService, patcherService);
            //var installerPresenter = new CreatorPresenter(installerView, settingsRepository, messageBoxService, pickerService, patcherService);

            //var random = new Random();
            //byte[] byte1 = new byte[0x2a000];
            //byte[] byte2 = new byte[0x2a000];
            //random.NextBytes(byte1);
            //random.NextBytes(byte2);
            //var package = new Model.ModPackage
            //{
            //    Mods = new System.Collections.Generic.List<ModPackage.Mod>
            //    {
            //        new ModPackage.Mod
            //        {
            //            Title = "tet",
            //            PakName = "test.pak",
            //            OriginalBytes = byte1,
            //            ModifiedBytes = byte2
            //        }
            //    }
            //};
            //File.WriteAllText("tet.json", JsonConvert.SerializeObject(package));

            Application.Run(installerView);
        }
    }
}
