using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.View;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    public partial class InstallerForm : Form, IInstallerView
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public InstallerForm()
        {
            InitializeComponent();
        }

        public InstallerPresenter Presenter { private get; set; }

        public string PaksPath
        {
            get => this.paksPathTextBox.Text;
            set => this.paksPathTextBox.Text = value;
        }

        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == 0x84)
            //{  // Trap WM_NCHITTEST
            //    Point pos = new Point(m.LParam.ToInt32());
            //    pos = this.PointToClient(pos);
            //    if (pos.Y < cCaption)
            //    {
            //        m.Result = (IntPtr)2;  // HTCAPTION
            //        return;
            //    }
            //    if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
            //    {
            //        m.Result = (IntPtr)17; // HTBOTTOMRIGHT
            //        return;
            //    }
            //}
            base.WndProc(ref m);
        }

        private void CloseToolbarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeToolbarButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //hack to make the form movable
        private void ToolbarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            toolbarPanel.Capture = false;
            Message mouse = Message.Create(Handle, WM_NCLBUTTONDOWN, new IntPtr(HT_CAPTION), IntPtr.Zero);
            WndProc(ref mouse);
        }

        private async void InstallButton_Click(object sender, EventArgs e)
        {
            await Presenter.InstallMod();
        }

        private async void UninstallButton_Click(object sender, EventArgs e)
        {
            await Presenter.UninstallMod();
        }

        private void ChangePaksPathButton_Click(object sender, EventArgs e)
        {
            Presenter.ChangePaksPath();
        }

        private void CreatePackageButton_Click(object sender, EventArgs e)
        {
            Presenter.DisplayCreator();
        }

        private void DiscordInviteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.discordInviteLinkLabel.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://discord.gg/sNDK9qzCcn");
        }

        private void TwitchLinkLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.twitchLinkLinkLabel.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.twitch.tv/thegrundo");
        }
    }
}
