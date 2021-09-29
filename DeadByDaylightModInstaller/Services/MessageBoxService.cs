using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool Question(string message)
        {
            DialogResult result = MessageBox.Show(message, AppDomain.CurrentDomain.BaseDirectory, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
