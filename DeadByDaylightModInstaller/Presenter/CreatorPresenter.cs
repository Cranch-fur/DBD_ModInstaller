using Dead_By_Daylight_Mod_Installer.Consts;
using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using Dead_By_Daylight_Mod_Installer.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dead_By_Daylight_Mod_Installer.Presenter
{
    public class CreatorPresenter
    {
        private readonly ICreatorView view;
        private readonly IMessageBoxService messageBoxService;
        private readonly IPickerService pickerService;
        private readonly List<ModListItem> package;
        private readonly IPackageService packageService;

        public CreatorPresenter(ICreatorView view, IPackageService packageService, IMessageBoxService messageBoxService, IPickerService pickerService)
        {
            this.view = view;
            this.view.Presenter = this;
            this.messageBoxService = messageBoxService;
            this.pickerService = pickerService;
            this.packageService = packageService;

            package = new List<ModListItem>();
            AddMod();
        }

        public void RemoveMod(ModListItem modListItem)
        {
            package.Remove(modListItem);
            view.ModListItems = package;
        }

        public void AddMod()
        {
            ModListItem modListItem = new ModListItem();
            modListItem.Rows = new List<ModListItem.Row>
            {
                new ModListItem.Row
                {
                    DisplayName = nameof(ModPackage.Mod.Title),
                    Name = ModListItem.Row.TitleRowName,
                    Data = "Mod",
                    Parent = modListItem
                },
                new ModListItem.Row
                {
                    DisplayName = nameof(ModPackage.Mod.PakName),
                    Name = ModListItem.Row.PakFileNameRowName,
                    Data = "",
                    Parent = modListItem
                },
                new ModListItem.Row
                {
                    DisplayName = "Original ubulk path",
                    Name = ModListItem.Row.OriginalUbulkPathRowName,
                    Data = "",
                    Parent = modListItem
                },
                new ModListItem.Row
                {
                    DisplayName = "Modified ubulk path",
                    Name = ModListItem.Row.ModifiedUbulkPathRowName,
                    Data = "",
                    Parent = modListItem
                },
            };
            package.Add(modListItem);
            view.ModListItems = package;
        }

        public void PickPakFile(ref ModListItem.Row row)
        {
            if (pickerService.PickFilePath(out string pakFilePath, Constants.PickPakFilter, Properties.Settings.Default.PaksPath) == Enums.PickResult.Ok)
            {
                row.Data = Path.GetFileName(pakFilePath);
            }
        }

        public void PickOriginalUbulkFile(ref ModListItem.Row row)
        {
            if (pickerService.PickFilePath(out string originalUbulkFilePath, Constants.PickUbulkFilter, Properties.Settings.Default.LastOriginalUbulkPath) == Enums.PickResult.Ok)
            {
                row.Data = originalUbulkFilePath;

                Properties.Settings.Default.LastOriginalUbulkPath = Path.GetDirectoryName(originalUbulkFilePath);
                Properties.Settings.Default.Save();
            }
        }


        public void PickModifiedUbulkFile(ref ModListItem.Row row)
        {
            if (pickerService.PickFilePath(out string modifiedUbulkFilePath, Constants.PickUbulkFilter, Properties.Settings.Default.LastModifiedUbulkPath) == Enums.PickResult.Ok)
            {
                row.Data = modifiedUbulkFilePath;

                Properties.Settings.Default.LastModifiedUbulkPath = Path.GetDirectoryName(modifiedUbulkFilePath);
                Properties.Settings.Default.Save();
            }
        }

        public void CreateModPackage()
        {
            foreach (ModListItem modListItem in package)
            {
                foreach (ModListItem.Row row in modListItem.Rows)
                {
                    if (string.IsNullOrWhiteSpace(row.Data))
                    {
                        ModListItem.Row modNameRow = modListItem.Rows.First(modListItemRow => modListItemRow.Name == ModListItem.Row.TitleRowName);
                        if (string.IsNullOrWhiteSpace(modNameRow.Data))
                        {
                            messageBoxService.ShowMessage("Mod title missing");
                        }
                        else
                        {
                            messageBoxService.ShowMessage($"Mod {modNameRow.Data} missing {row.DisplayName}");
                        }
                        return;
                    }
                }
            }

            Enums.PickResult pickResult = pickerService.PickSaveFilePath(out string filePath, Constants.ModSavePackageFilter);
            if (pickResult == Enums.PickResult.Ok)
            {
                try
                {
                    ModPackage modPackage = new ModPackage
                    {
                        Mods = package.Select(modListItem => new ModPackage.Mod
                        {
                            Title = modListItem.Rows.First(row => row.Name == ModListItem.Row.TitleRowName).Data,
                            PakName = modListItem.Rows.First(row => row.Name == ModListItem.Row.PakFileNameRowName).Data,
                            OriginalBytes = File.ReadAllBytes(modListItem.Rows.First(row => row.Name == ModListItem.Row.OriginalUbulkPathRowName).Data),
                            ModifiedBytes = File.ReadAllBytes(modListItem.Rows.First(row => row.Name == ModListItem.Row.ModifiedUbulkPathRowName).Data),
                        }).ToList()
                    };

                    packageService.SavePackage(filePath, modPackage, packageService.GetFormat(filePath));
                }
                catch (Exception ex)
                {
                    messageBoxService.ShowMessage(ex.Message);
                }
            }
            else if (pickResult == Enums.PickResult.None)
            {
                messageBoxService.ShowMessage("Failed to get save file path");
            }
        }
    }
}
