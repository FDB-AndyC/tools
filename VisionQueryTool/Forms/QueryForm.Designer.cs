// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryForm.Designer.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the QueryForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Forms
{
    public partial class QueryForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.executeButton = new System.Windows.Forms.Button();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ethnicityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referralsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // executeButton
            // 
            this.executeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.executeButton.Location = new System.Drawing.Point(0, 266);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(663, 23);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButtonClick);
            // 
            // queryTextBox
            // 
            this.queryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryTextBox.Location = new System.Drawing.Point(0, 24);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.queryTextBox.Size = new System.Drawing.Size(663, 242);
            this.queryTextBox.TabIndex = 1;
            this.queryTextBox.Text = "SELECT * \r\nFROM ";
            this.queryTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.QueryTextBoxPreviewKeyDown);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(663, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientMenuItem,
            this.ethnicityMenuItem,
            this.addressMenuItem,
            this.joinedMenuItem,
            this.referralsMenuItem,
            this.toolStripSeparator1,
            this.closeMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // patientMenuItem
            // 
            this.patientMenuItem.Name = "patientMenuItem";
            this.patientMenuItem.Size = new System.Drawing.Size(247, 22);
            this.patientMenuItem.Text = "Patient";
            this.patientMenuItem.Click += new System.EventHandler(this.PatientMenuItemClick);
            // 
            // ethnicityMenuItem
            // 
            this.ethnicityMenuItem.Name = "ethnicityMenuItem";
            this.ethnicityMenuItem.Size = new System.Drawing.Size(247, 22);
            this.ethnicityMenuItem.Text = "Ethnicity";
            this.ethnicityMenuItem.Click += new System.EventHandler(this.EthnicityMenuItemClick);
            // 
            // addressMenuItem
            // 
            this.addressMenuItem.Name = "addressMenuItem";
            this.addressMenuItem.Size = new System.Drawing.Size(247, 22);
            this.addressMenuItem.Text = "Address";
            this.addressMenuItem.Click += new System.EventHandler(this.AddressMenuItemClick);
            // 
            // joinedMenuItem
            // 
            this.joinedMenuItem.Name = "joinedMenuItem";
            this.joinedMenuItem.Size = new System.Drawing.Size(247, 22);
            this.joinedMenuItem.Text = "Sidebar joined GetAddressDetails";
            this.joinedMenuItem.Click += new System.EventHandler(this.JoinedMenuItemClick);
            // 
            // referralsMenuItem
            // 
            this.referralsMenuItem.Name = "referralsMenuItem";
            this.referralsMenuItem.Size = new System.Drawing.Size(247, 22);
            this.referralsMenuItem.Text = "Referrals";
            this.referralsMenuItem.Click += new System.EventHandler(this.ReferralsMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(247, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItemClick);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 289);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MinimizeBox = false;
            this.Name = "QueryForm";
            this.Text = "Vision Query Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QueryFormClosed);
            this.Load += new System.EventHandler(this.QueryFormLoad);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ethnicityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referralsMenuItem;
    }
}