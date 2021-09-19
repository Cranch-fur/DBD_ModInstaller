using Dead_By_Daylight_Mod_Installer.Enums;
using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer.Services
{
    public class PickerService : IPickerService
    {
        public PickResult PickFolder(out string folderPath)
        {
            folderPath = string.Empty;
            try
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        folderPath = folderBrowserDialog.SelectedPath;
                        return PickResult.Ok;
                    }
                    else
                    {
                        return PickResult.Cancel;
                    }
                }
            }
            catch(Exception)
            { }

            return PickResult.None;
        }

        public PickResult PickFilePath(out string filePath, string filter)
        {
            filePath = string.Empty;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                    openFileDialog.Filter = filter;
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        return PickResult.Ok;
                    }
                    else
                    {
                        return PickResult.Cancel;
                    }
                }
            }
            catch { }

            return PickResult.None;
        }

        public PickResult PickSaveFilePath(out string filePath)
        {
            filePath = string.Empty;

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
                    saveFileDialog.Filter = "Json Mod Package|*.json";
                    saveFileDialog.FilterIndex = 1;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        return PickResult.Ok;
                    }
                    else
                    {
                        return PickResult.Cancel;
                    }
                }
            }
            catch { }

            return PickResult.None;
        }
    }
}
