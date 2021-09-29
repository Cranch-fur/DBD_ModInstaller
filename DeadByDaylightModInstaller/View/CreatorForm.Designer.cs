
namespace Dead_By_Daylight_Mod_Installer
{
    partial class CreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatorForm));
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.minimizeToolbarButton = new System.Windows.Forms.Button();
            this.closeToolbarButton = new System.Windows.Forms.Button();
            this.generatePackageButton = new System.Windows.Forms.Button();
            this.modsTreeListView = new BrightIdeasSoftware.TreeListView();
            this.displayColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dataColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.actionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.addModButton = new System.Windows.Forms.Button();
            this.removeModButton = new System.Windows.Forms.Button();
            this.toolbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modsTreeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolbarPanel.Controls.Add(this.minimizeToolbarButton);
            this.toolbarPanel.Controls.Add(this.closeToolbarButton);
            this.toolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(659, 23);
            this.toolbarPanel.TabIndex = 2;
            this.toolbarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolbarPanel_MouseDown);
            // 
            // minimizeToolbarButton
            // 
            this.minimizeToolbarButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.minimizeToolbarButton.FlatAppearance.BorderSize = 0;
            this.minimizeToolbarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeToolbarButton.ForeColor = System.Drawing.Color.White;
            this.minimizeToolbarButton.Location = new System.Drawing.Point(609, 0);
            this.minimizeToolbarButton.Name = "minimizeToolbarButton";
            this.minimizeToolbarButton.Size = new System.Drawing.Size(24, 23);
            this.minimizeToolbarButton.TabIndex = 1;
            this.minimizeToolbarButton.Text = "—";
            this.minimizeToolbarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minimizeToolbarButton.UseVisualStyleBackColor = false;
            this.minimizeToolbarButton.Click += new System.EventHandler(this.MinimizeToolbarButton_Click);
            // 
            // closeToolbarButton
            // 
            this.closeToolbarButton.BackColor = System.Drawing.Color.IndianRed;
            this.closeToolbarButton.FlatAppearance.BorderSize = 0;
            this.closeToolbarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeToolbarButton.ForeColor = System.Drawing.Color.White;
            this.closeToolbarButton.Location = new System.Drawing.Point(635, 0);
            this.closeToolbarButton.Name = "closeToolbarButton";
            this.closeToolbarButton.Size = new System.Drawing.Size(24, 23);
            this.closeToolbarButton.TabIndex = 0;
            this.closeToolbarButton.Text = "X";
            this.closeToolbarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeToolbarButton.UseVisualStyleBackColor = false;
            this.closeToolbarButton.Click += new System.EventHandler(this.CloseToolbarButton_Click);
            // 
            // generatePackageButton
            // 
            this.generatePackageButton.Location = new System.Drawing.Point(238, 407);
            this.generatePackageButton.Name = "generatePackageButton";
            this.generatePackageButton.Size = new System.Drawing.Size(122, 23);
            this.generatePackageButton.TabIndex = 24;
            this.generatePackageButton.Text = "Generate package";
            this.generatePackageButton.UseVisualStyleBackColor = true;
            this.generatePackageButton.Click += new System.EventHandler(this.GeneratePackageButton_Click);
            // 
            // modsTreeListView
            // 
            this.modsTreeListView.AllColumns.Add(this.displayColumn);
            this.modsTreeListView.AllColumns.Add(this.dataColumn);
            this.modsTreeListView.AllColumns.Add(this.actionColumn);
            this.modsTreeListView.CellEditUseWholeCell = false;
            this.modsTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.displayColumn,
            this.dataColumn,
            this.actionColumn});
            this.modsTreeListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.modsTreeListView.EmptyListMsg = "Drop something here";
            this.modsTreeListView.HideSelection = false;
            this.modsTreeListView.IsSimpleDragSource = true;
            this.modsTreeListView.IsSimpleDropSink = true;
            this.modsTreeListView.Location = new System.Drawing.Point(12, 206);
            this.modsTreeListView.MultiSelect = false;
            this.modsTreeListView.Name = "modsTreeListView";
            this.modsTreeListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.modsTreeListView.ShowGroups = false;
            this.modsTreeListView.ShowItemToolTips = true;
            this.modsTreeListView.Size = new System.Drawing.Size(561, 195);
            this.modsTreeListView.TabIndex = 0;
            this.modsTreeListView.UseCompatibleStateImageBehavior = false;
            this.modsTreeListView.View = System.Windows.Forms.View.Details;
            this.modsTreeListView.VirtualMode = true;
            this.modsTreeListView.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.ModsTreeListView_ButtonClick);
            this.modsTreeListView.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ModsTreeListView_CellEditStarting);
            this.modsTreeListView.SelectionChanged += new System.EventHandler(this.ModsTreeListView_SelectionChanged);
            // 
            // displayColumn
            // 
            this.displayColumn.Text = "Name";
            this.displayColumn.Width = 125;
            // 
            // dataColumn
            // 
            this.dataColumn.Text = "Data";
            this.dataColumn.Width = 376;
            // 
            // actionColumn
            // 
            this.actionColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.actionColumn.IsButton = true;
            this.actionColumn.Text = "";
            // 
            // addModButton
            // 
            this.addModButton.Location = new System.Drawing.Point(579, 206);
            this.addModButton.Name = "addModButton";
            this.addModButton.Size = new System.Drawing.Size(68, 23);
            this.addModButton.TabIndex = 25;
            this.addModButton.Text = "Add";
            this.addModButton.UseVisualStyleBackColor = true;
            this.addModButton.Click += new System.EventHandler(this.AddModButton_Click);
            // 
            // removeModButton
            // 
            this.removeModButton.Enabled = false;
            this.removeModButton.Location = new System.Drawing.Point(579, 235);
            this.removeModButton.Name = "removeModButton";
            this.removeModButton.Size = new System.Drawing.Size(68, 23);
            this.removeModButton.TabIndex = 26;
            this.removeModButton.Text = "Remove";
            this.removeModButton.UseVisualStyleBackColor = true;
            this.removeModButton.Click += new System.EventHandler(this.RemoveModButton_Click);
            // 
            // CreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Dead_By_Daylight_Mod_Installer.Properties.Resources.background_creator;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(659, 434);
            this.Controls.Add(this.removeModButton);
            this.Controls.Add(this.addModButton);
            this.Controls.Add(this.modsTreeListView);
            this.Controls.Add(this.generatePackageButton);
            this.Controls.Add(this.toolbarPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatorForm";
            this.Text = "Dead By Daylight Mod Installer";
            this.toolbarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modsTreeListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Button minimizeToolbarButton;
        private System.Windows.Forms.Button closeToolbarButton;
        private System.Windows.Forms.Button generatePackageButton;
        private BrightIdeasSoftware.TreeListView modsTreeListView;
        private BrightIdeasSoftware.OLVColumn displayColumn;
        private BrightIdeasSoftware.OLVColumn actionColumn;
        private BrightIdeasSoftware.OLVColumn dataColumn;
        private System.Windows.Forms.Button addModButton;
        private System.Windows.Forms.Button removeModButton;
    }
}

