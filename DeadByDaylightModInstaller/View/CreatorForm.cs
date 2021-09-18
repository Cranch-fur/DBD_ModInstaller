using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.View;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    public partial class CreatorForm : Form, ICreatorView
    {
        public CreatorForm()
        {
            InitializeComponent();
        }

        public CreatorPresenter Presenter { private get; set; }

        public string ModTitle
        {
            get => this.TitleTextBox.Text;
            set => this.TitleTextBox.Text = value;
        }
        
        public string PakFileName
        {
            get => this.pakNameTextBox.Text;
            set => this.pakNameTextBox.Text = value;
        }

        public string OriginalFilePath
        {
            get => this.OriginalTexturePathTextBox.Text;
            set => this.OriginalTexturePathTextBox.Text = value;
        }

        public string ModifiedFilePath
        {
            get => this.ModifiedTexturePathTextBox.Text;
            set => this.ModifiedTexturePathTextBox.Text = value;
        }

        private void CloseToolbarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeToolbarButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //seems like a hack to make the form movable
        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;
        private void ToolbarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            toolbarPanel.Capture = false;
            Message mouse = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref mouse);
        }

        private void PakNameTextBox_Click(object sender, EventArgs e)
        {
            Presenter.PickPakFile();
        }

        private void OriginalTexturePathTextBox_Click(object sender, EventArgs e)
        {
            Presenter.PickOriginalFile();
        }

        private void ModifiedTexturePathTextBox_Click(object sender, EventArgs e)
        {
            Presenter.PickModifiedFile();
        }

        private void CreateJsonButton_Click(object sender, EventArgs e)
        {
            Presenter.CreateModPackage();
        }
    }
}
