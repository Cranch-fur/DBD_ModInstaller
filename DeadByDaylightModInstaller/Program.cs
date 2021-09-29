using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.Services;
using System;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InstallerForm installerView = new InstallerForm();
            MessageBoxService messageBoxService = new MessageBoxService();
            PickerService pickerService = new PickerService();
            PatchService patcherService = new PatchService();
            PackageService packageService = new PackageService();

            InstallerPresenter installerPresenter = new InstallerPresenter(installerView, packageService, messageBoxService, pickerService, patcherService);

            Application.Run(installerView);
        }
    }
}
