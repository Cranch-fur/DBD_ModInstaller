
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatorForm));
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.minimizeToolbarButton = new System.Windows.Forms.Button();
            this.closeToolbarButton = new System.Windows.Forms.Button();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.pakNameTextBox = new System.Windows.Forms.TextBox();
            this.OriginalTexturePathTextBox = new System.Windows.Forms.TextBox();
            this.ModifiedTexturePathTextBox = new System.Windows.Forms.TextBox();
            this.modTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.createJsonButton = new System.Windows.Forms.Button();
            this.toolbarPanel.SuspendLayout();
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
            // TitleTextBox
            // 
            this.TitleTextBox.BackColor = System.Drawing.Color.White;
            this.TitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleTextBox.Location = new System.Drawing.Point(147, 268);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(404, 21);
            this.TitleTextBox.TabIndex = 16;
            // 
            // pakNameTextBox
            // 
            this.pakNameTextBox.BackColor = System.Drawing.Color.White;
            this.pakNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pakNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pakNameTextBox.Location = new System.Drawing.Point(147, 295);
            this.pakNameTextBox.Name = "pakNameTextBox";
            this.pakNameTextBox.ReadOnly = true;
            this.pakNameTextBox.Size = new System.Drawing.Size(404, 21);
            this.pakNameTextBox.TabIndex = 17;
            this.pakNameTextBox.Click += new System.EventHandler(this.PakNameTextBox_Click);
            // 
            // OriginalTexturePathTextBox
            // 
            this.OriginalTexturePathTextBox.BackColor = System.Drawing.Color.White;
            this.OriginalTexturePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalTexturePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OriginalTexturePathTextBox.Location = new System.Drawing.Point(147, 322);
            this.OriginalTexturePathTextBox.Name = "OriginalTexturePathTextBox";
            this.OriginalTexturePathTextBox.ReadOnly = true;
            this.OriginalTexturePathTextBox.Size = new System.Drawing.Size(404, 21);
            this.OriginalTexturePathTextBox.TabIndex = 18;
            this.OriginalTexturePathTextBox.Click += new System.EventHandler(this.OriginalTexturePathTextBox_Click);
            // 
            // ModifiedTexturePathTextBox
            // 
            this.ModifiedTexturePathTextBox.BackColor = System.Drawing.Color.White;
            this.ModifiedTexturePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModifiedTexturePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModifiedTexturePathTextBox.Location = new System.Drawing.Point(147, 349);
            this.ModifiedTexturePathTextBox.Name = "ModifiedTexturePathTextBox";
            this.ModifiedTexturePathTextBox.ReadOnly = true;
            this.ModifiedTexturePathTextBox.Size = new System.Drawing.Size(404, 21);
            this.ModifiedTexturePathTextBox.TabIndex = 19;
            this.ModifiedTexturePathTextBox.Click += new System.EventHandler(this.ModifiedTexturePathTextBox_Click);
            // 
            // modTitleLabel
            // 
            this.modTitleLabel.AutoSize = true;
            this.modTitleLabel.Location = new System.Drawing.Point(53, 272);
            this.modTitleLabel.Name = "modTitleLabel";
            this.modTitleLabel.Size = new System.Drawing.Size(47, 13);
            this.modTitleLabel.TabIndex = 20;
            this.modTitleLabel.Text = "Mod title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pak file name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Original file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Modified file";
            // 
            // createJsonButton
            // 
            this.createJsonButton.Location = new System.Drawing.Point(285, 407);
            this.createJsonButton.Name = "createJsonButton";
            this.createJsonButton.Size = new System.Drawing.Size(75, 23);
            this.createJsonButton.TabIndex = 24;
            this.createJsonButton.Text = "Create json";
            this.createJsonButton.UseVisualStyleBackColor = true;
            this.createJsonButton.Click += new System.EventHandler(this.CreateJsonButton_Click);
            // 
            // CreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Dead_By_Daylight_Mod_Installer.Properties.Resources.background_creator;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(659, 434);
            this.Controls.Add(this.createJsonButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modTitleLabel);
            this.Controls.Add(this.ModifiedTexturePathTextBox);
            this.Controls.Add(this.OriginalTexturePathTextBox);
            this.Controls.Add(this.pakNameTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.toolbarPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatorForm";
            this.Text = "Dead By Daylight Mod Installer";
            this.toolbarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Button minimizeToolbarButton;
        private System.Windows.Forms.Button closeToolbarButton;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox pakNameTextBox;
        private System.Windows.Forms.TextBox OriginalTexturePathTextBox;
        private System.Windows.Forms.TextBox ModifiedTexturePathTextBox;
        private System.Windows.Forms.Label modTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createJsonButton;
    }
}

