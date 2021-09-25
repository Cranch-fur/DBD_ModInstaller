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
            var messageBoxService = new MessageBoxService();
            var pickerService = new PickerService();
            var patcherService = new PatchService();
            var packageService = new PackageService();

            var installerPresenter = new InstallerPresenter(installerView, packageService, messageBoxService, pickerService, patcherService);

            Application.Run(installerView);
        }
    }
}
