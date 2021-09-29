using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Presenter;
using Dead_By_Daylight_Mod_Installer.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    public partial class CreatorForm : Form, ICreatorView
    {
        public List<ModListItem> ModListItems
        {
            get => modsTreeListView.Roots as List<ModListItem>;
            set => modsTreeListView.Roots = value;
        }

        public CreatorForm()
        {
            InitializeComponent();

            actionColumn.AspectGetter = ActionColumnAspectGetter;
            displayColumn.AspectGetter = DisplayColumnAspectGetter;
            dataColumn.AspectGetter = DataColumnAspectGetter;
            dataColumn.AspectPutter = DataColumnAspectPutter;
            modsTreeListView.CanExpandGetter = ModsTreeListViewCanExpandGetter;
            modsTreeListView.ChildrenGetter = ModsTreeListViewChildrenGetter;
        }

        public CreatorPresenter Presenter { private get; set; }


        private object DisplayColumnAspectGetter(object model)
        {
            if (model is ModListItem modModel)
            {
                return modModel.Rows.FirstOrDefault()?.Data ?? string.Empty;
            }
            else if (model is ModListItem.Row rowModel)
            {
                return rowModel.DisplayName;
            }
            return string.Empty;
        }

        private object DataColumnAspectGetter(object model)
        {
            if (model is ModListItem.Row rowModel)
            {
                return rowModel.Data;
            }
            return string.Empty;
        }

        private void DataColumnAspectPutter(object model, object newValue)
        {
            if (model is ModListItem.Row rowModel && rowModel.Name == ModListItem.Row.TitleRowName)
            {
                rowModel.Data = newValue.ToString();
            }
        }

        private bool ModsTreeListViewCanExpandGetter(object model)
        {
            return model is ModListItem;
        }

        private IEnumerable ModsTreeListViewChildrenGetter(object model)
        {
            if (model is ModListItem modModel)
            {
                return modModel.Rows;
            }

            return null;
        }

        private object ActionColumnAspectGetter(object model)
        {
            return model is ModListItem.Row ? "Change" : null;
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

        private void GeneratePackageButton_Click(object sender, EventArgs e)
        {
            Presenter.CreateModPackage();
        }

        private void AddModButton_Click(object sender, EventArgs e)
        {
            Presenter.AddMod();
        }

        private void RemoveModButton_Click(object sender, EventArgs e)
        {
            foreach (object row in modsTreeListView.SelectedObjects)
            {
                if (row is ModListItem modListItem)
                {
                    Presenter.RemoveMod(modListItem);
                }
                else if (row is ModListItem.Row modListItemRow)
                {
                    Presenter.RemoveMod(modListItemRow.Parent);
                }
            }
        }

        private void ModsTreeListView_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            ModListItem.Row row = e.Model as ModListItem.Row;
            if (row.Name == ModListItem.Row.TitleRowName)
            {
                modsTreeListView.StartCellEdit(e.Item, 1);
            }
            else if (row.Name == ModListItem.Row.PakFileNameRowName)
            {
                Presenter.PickPakFile(ref row);
            }
            else if (row.Name == ModListItem.Row.OriginalUbulkPathRowName)
            {
                Presenter.PickOriginalUbulkFile(ref row);
            }
            else if (row.Name == ModListItem.Row.ModifiedUbulkPathRowName)
            {
                Presenter.PickModifiedUbulkFile(ref row);
            }
        }

        private void ModsTreeListView_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs args)
        {
            // Left align the edit control
            args.Control.Location = args.CellBounds.Location;

            // Readjust the size of the control to fill the whole cell if CellEditUseWholeCellEffective is enabled
            if (args.Column.CellEditUseWholeCellEffective)
            {
                args.Control.Size = args.CellBounds.Size;
            }
        }

        private void ModsTreeListView_SelectionChanged(object sender, EventArgs e)
        {
            removeModButton.Enabled = modsTreeListView.SelectedObject is ModListItem;
        }
    }
}
