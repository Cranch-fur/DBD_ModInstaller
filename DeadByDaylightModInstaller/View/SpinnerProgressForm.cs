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
    public partial class SpinnerProgressForm : Form, ISpinnerProgressView
    {
        private readonly Label messageLabel;

        public SpinnerProgressForm()
        {
            InitializeComponent();

            messageLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                //Location = new System.Drawing.Point(72, 27),
                Name = "messageLabel",
                Size = new Size(86, 31),
                TabIndex = 1,
                Text = "label1"
            };
            flowLayoutPanel1.Controls.Add(messageLabel);
        }

        public SpinnerProgressPresenter Presenter { private get; set; }

        public string Message
        {
            get => this.messageLabel.Text;
            set => this.messageLabel.Text = value;
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
