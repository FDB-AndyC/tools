// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.Designer.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the MainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisionAddressTool
{
    public partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QueryButton = new System.Windows.Forms.Button();
            this.PatientIdTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QueryButton);
            this.groupBox1.Controls.Add(this.PatientIdTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(13);
            this.groupBox1.Size = new System.Drawing.Size(469, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Id";
            // 
            // QueryButton
            // 
            this.QueryButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QueryButton.Location = new System.Drawing.Point(13, 56);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(443, 23);
            this.QueryButton.TabIndex = 1;
            this.QueryButton.Text = "Query";
            this.QueryButton.UseVisualStyleBackColor = true;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // PatientIdTextBox
            // 
            this.PatientIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientIdTextBox.Location = new System.Drawing.Point(13, 28);
            this.PatientIdTextBox.Name = "PatientIdTextBox";
            this.PatientIdTextBox.Size = new System.Drawing.Size(443, 22);
            this.PatientIdTextBox.TabIndex = 0;
            this.PatientIdTextBox.Text = "0";
            this.PatientIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PatientIdTextBox_Validating);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextBox.Location = new System.Drawing.Point(0, 92);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputTextBox.Size = new System.Drawing.Size(469, 202);
            this.OutputTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AcceptButton = this.QueryButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(469, 294);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Vision Address Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PatientIdTextBox;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.TextBox OutputTextBox;
    }
}

