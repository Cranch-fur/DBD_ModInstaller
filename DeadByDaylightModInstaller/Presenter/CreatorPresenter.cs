using Dead_By_Daylight_Mod_Installer.Consts;
using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using Dead_By_Daylight_Mod_Installer.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Presenter
{
    public class CreatorPresenter
    {
        private readonly ICreatorView view;
        private readonly IMessageBoxService messageBoxService;
        private readonly IPickerService pickerService;
        private readonly IPackageService packageService;

        public CreatorPresenter(ICreatorView view, IPackageService packageService, IMessageBoxService messageBoxService, IPickerService pickerService)
        {
            this.view = view;
            this.view.Presenter = this;
            this.messageBoxService = messageBoxService;
            this.pickerService = pickerService;
            this.packageService = packageService;
        }

        public void PickPakFile()
        {
            if(pickerService.PickFilePath(out string pakFilePath, "Pak file|*.pak", Properties.Settings.Default.PaksPath) == Enums.PickResult.Ok)
            {
                view.PakFileName = Path.GetFileName(pakFilePath);
            }
        }

        public void PickOriginalFile()
        {
            if (pickerService.PickFilePath(out string originalFilePath, "ubulk (*.ubulk)|*.ubulk|All files (*.*)|*.*") == Enums.PickResult.Ok)
            {
                view.OriginalFilePath = originalFilePath;
            }
        }

        public void PickModifiedFile()
        {
            if (pickerService.PickFilePath(out string modifiedFilePath, "ubulk (*.ubulk)|*.ubulk|All files (*.*)|*.*") == Enums.PickResult.Ok)
            {
                view.ModifiedFilePath = modifiedFilePath;
            }
        }

        public void CreateModPackage()
        {
            if(string.IsNullOrWhiteSpace(view.ModTitle) || string.IsNullOrWhiteSpace(view.PakFileName)
                || string.IsNullOrWhiteSpace(view.ModTitle) || string.IsNullOrWhiteSpace(view.PakFileName))
            {
                messageBoxService.ShowMessage("One of the fields is empty");
                return;
            }

            var pickResult = pickerService.PickSaveFilePath(out string filePath, Constants.ModPackageFilter);
            if (pickResult == Enums.PickResult.Ok)
            {
                var modPackage = new ModPackage
                {
                    Mods = new List<ModPackage.Mod>
                    {
                        new ModPackage.Mod
                        {
                            Title = view.ModTitle,
                            PakName = view.PakFileName,
                            OriginalBytes = File.ReadAllBytes(view.OriginalFilePath),
                            ModifiedBytes = File.ReadAllBytes(view.ModifiedFilePath),
                        }
                    }
                };

                try
                {
                    packageService.SavePackage(filePath, modPackage, packageService.GetFormat(filePath));
                }
                catch(Exception ex)
                {
                    messageBoxService.ShowMessage(ex.Message);
                }
            }
            else if(pickResult == Enums.PickResult.None)
            {
                messageBoxService.ShowMessage("Failed to get save file path");
            }
        }
    }
}
