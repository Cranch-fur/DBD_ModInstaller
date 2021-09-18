using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
            //MessageBox.Show($"\"{(string)jsEntry["modtitle"]}\" Mod successfully uninstalled!", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

        public bool Question(string message)
        {
            //MessageBox.Show($"Do you want to uninstall \"{(string)jsEntry["modtitle"]}\"?", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            var result = MessageBox.Show(message, AppDomain.CurrentDomain.BaseDirectory, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
