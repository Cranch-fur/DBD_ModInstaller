using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.View;
using System;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    public partial class SpinnerProgressForm : Form, ISpinnerProgressView
    {
        public SpinnerProgressForm()
        {
            InitializeComponent();
        }

        public SpinnerProgressPresenter Presenter { private get; set; }

        public string Message
        {
            get => messageLabel.Text;
            set => messageLabel.Text = value;
        }

        public void Popup()
        {
            ShowDialog();
        }

        public void Dismiss()
        {
            Close();
        }

        private async void SpinnerProgressForm_Load(object sender, EventArgs e)
        {
            await Presenter.AwaitWorkAndDismiss();
        }
    }
}
