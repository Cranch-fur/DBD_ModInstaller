using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.View;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    public partial class CreatorForm : Form, ICreatorView
    {
        public List<ModListItem> ModListItems
        {
            get => this.modsTreeListView.Roots as List<ModListItem>;
            set => this.modsTreeListView.Roots = value;
        }


        public CreatorForm()
        {
            InitializeComponent();

            this.modsTreeListView.ButtonClick += ModsTreeListView_ButtonClick;

            this.actionColumn.AspectGetter = model => model is ModListItem.Row ? "Change" : null;

            this.displayColumn.AspectGetter = model =>
            {
                if(model is ModListItem modModel)
                {
                    return modModel.Rows.FirstOrDefault()?.Data ?? string.Empty;
                }
                else if (model is ModListItem.Row rowModel)
                {
                    return rowModel.DisplayName;
                }
                return string.Empty;
            };
            this.dataColumn.AspectGetter = model =>
            {
                if (model is ModListItem.Row rowModel)
                {
                    return rowModel.Data;
                }
                return string.Empty;
            };
            this.dataColumn.AspectPutter = (model, newValue) =>
            {
                if (model is ModListItem.Row rowModel && rowModel.Name == ModListItem.Row.TitleRowName)
                {
                    rowModel.Data = newValue;
                }
            };
            this.modsTreeListView.CanExpandGetter =  model => model is ModListItem;
            this.modsTreeListView.ChildrenGetter = model =>
            {
                if(model is ModListItem modModel)
                {
                    return modModel.Rows;
                }
                return null;
            };
            this.modsTreeListView.ShowItemToolTips = true;
        }

        public CreatorPresenter Presenter { private get; set; }

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

        private void GeneratePackageButton_Click(object sender, EventArgs e)
        {
            Presenter.CreateModPackage();
        }

        private void AddModButton_Click(object sender, EventArgs e)
        {
            Presenter.AddMod();
        }

        private void ModsTreeListView_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var row = e.Model as ModListItem.Row;
            if (row.Name == ModListItem.Row.TitleRowName)
            {
                this.modsTreeListView.StartCellEdit(e.Item, 1);
            }
            else if (row.Name == ModListItem.Row.PakFileNameRowName)
            {
                Presenter.PickPakFile(ref row);
            }
            else if (row.Name == ModListItem.Row.OriginalUbulkPathRowName || row.Name == ModListItem.Row.ModifiedUbulkPathRowName)
            {
                Presenter.PickUbulkFile(ref row);
            }
        }

        private void modsTreeListView_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs args)
        {
            // Left align the edit control
            args.Control.Location = args.CellBounds.Location;

            // Readjust the size of the control to fill the whole cell if CellEditUseWholeCellEffective is enabled
            if (args.Column.CellEditUseWholeCellEffective)
            {
                args.Control.Size = args.CellBounds.Size;
            }
        }
    }
}
