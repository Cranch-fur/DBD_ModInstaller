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
        private List<ModListItem> package;
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

        public void AddMod()
        {
            package.Add(new ModListItem
            {
                Rows = new List<ModListItem.Row>
                {
                    new ModListItem.Row
                    {
                        DisplayName = nameof(ModPackage.Mod.Title),
                        Name = ModListItem.Row.TitleRowName,
                        Data = "Package",
                    },
                    new ModListItem.Row
                    {
                        DisplayName = nameof(ModPackage.Mod.PakName),
                        Name = ModListItem.Row.PakFileNameRowName,
                        Data = "",
                    },
                    new ModListItem.Row
                    {
                        DisplayName = "Original ubulk path",
                        Name = ModListItem.Row.OriginalUbulkPathRowName,
                        Data = "",
                    },
                    new ModListItem.Row
                    {
                        DisplayName = "Modified ubulk path",
                        Name = ModListItem.Row.ModifiedUbulkPathRowName,
                        Data = "",
                    },
                }
            });
            view.ModListItems = package;
        }

        public void PickPakFile(ref ModListItem.Row row)
        {
            if(pickerService.PickFilePath(out string pakFilePath, "Pak file|*.pak") == Enums.PickResult.Ok)
            {
                row.Data = Path.GetFileName(pakFilePath);
            }
        }

        public void PickUbulkFile(ref ModListItem.Row row)
        {
            if (pickerService.PickFilePath(out string originalFilePath, "ubulk (*.ubulk)|*.ubulk|All files (*.*)|*.*") == Enums.PickResult.Ok)
            {
                row.Data = originalFilePath;
            }
        }

        public void CreateModPackage()
        {
            foreach (var modListItem in package)
            {
                foreach (var row in modListItem.Rows)
                {
                    if (string.IsNullOrWhiteSpace(row.Data))
                    {
                        var modNameRow = modListItem.Rows.First(modListItemRow => modListItemRow.Name == ModListItem.Row.TitleRowName);
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

            var pickResult = pickerService.PickSaveFilePath(out string filePath);
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
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(modPackage));
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
