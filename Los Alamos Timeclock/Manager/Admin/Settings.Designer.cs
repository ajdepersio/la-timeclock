﻿namespace Los_Alamos_Timeclock
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.ipaddressLLabel = new System.Windows.Forms.LinkLabel();
            this.portLLabel = new System.Windows.Forms.LinkLabel();
            this.userLLabel = new System.Windows.Forms.LinkLabel();
            this.passLLabel = new System.Windows.Forms.LinkLabel();
            this.ipaddressTextbox = new System.Windows.Forms.TextBox();
            this.portTextbox = new System.Windows.Forms.TextBox();
            this.userTextbox = new System.Windows.Forms.TextBox();
            this.passTextbox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.databaseTextbox = new System.Windows.Forms.TextBox();
            this.databaseLLabel = new System.Windows.Forms.LinkLabel();
            this.appSettingsLabel = new System.Windows.Forms.Label();
            this.showCurrentEmployeesCheckbox = new System.Windows.Forms.CheckBox();
            this.showPreviousEmployeesCheckbox = new System.Windows.Forms.CheckBox();
            this.saveAppSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(185, 210);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(159, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Database Settings";
            // 
            // ipaddressLLabel
            // 
            this.ipaddressLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ipaddressLLabel.AutoSize = true;
            this.ipaddressLLabel.BackColor = System.Drawing.Color.Transparent;
            this.ipaddressLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipaddressLLabel.ForeColor = System.Drawing.Color.White;
            this.ipaddressLLabel.LinkColor = System.Drawing.Color.White;
            this.ipaddressLLabel.Location = new System.Drawing.Point(92, 262);
            this.ipaddressLLabel.Name = "ipaddressLLabel";
            this.ipaddressLLabel.Size = new System.Drawing.Size(91, 20);
            this.ipaddressLLabel.TabIndex = 1;
            this.ipaddressLLabel.TabStop = true;
            this.ipaddressLLabel.Text = "IP Address:";
            this.ipaddressLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ipLLabel_LinkClicked);
            // 
            // portLLabel
            // 
            this.portLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.portLLabel.AutoSize = true;
            this.portLLabel.BackColor = System.Drawing.Color.Transparent;
            this.portLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLLabel.ForeColor = System.Drawing.Color.White;
            this.portLLabel.LinkColor = System.Drawing.Color.White;
            this.portLLabel.Location = new System.Drawing.Point(141, 297);
            this.portLLabel.Name = "portLLabel";
            this.portLLabel.Size = new System.Drawing.Size(42, 20);
            this.portLLabel.TabIndex = 2;
            this.portLLabel.TabStop = true;
            this.portLLabel.Text = "Port:";
            this.portLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.portLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.portLLabel_LinkClicked);
            // 
            // userLLabel
            // 
            this.userLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userLLabel.AutoSize = true;
            this.userLLabel.BackColor = System.Drawing.Color.Transparent;
            this.userLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLLabel.ForeColor = System.Drawing.Color.White;
            this.userLLabel.LinkColor = System.Drawing.Color.White;
            this.userLLabel.Location = new System.Drawing.Point(134, 358);
            this.userLLabel.Name = "userLLabel";
            this.userLLabel.Size = new System.Drawing.Size(47, 20);
            this.userLLabel.TabIndex = 3;
            this.userLLabel.TabStop = true;
            this.userLLabel.Text = "User:";
            this.userLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.userLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.userLLabel_LinkClicked);
            // 
            // passLLabel
            // 
            this.passLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passLLabel.AutoSize = true;
            this.passLLabel.BackColor = System.Drawing.Color.Transparent;
            this.passLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLLabel.ForeColor = System.Drawing.Color.White;
            this.passLLabel.LinkColor = System.Drawing.Color.White;
            this.passLLabel.Location = new System.Drawing.Point(99, 390);
            this.passLLabel.Name = "passLLabel";
            this.passLLabel.Size = new System.Drawing.Size(82, 20);
            this.passLLabel.TabIndex = 4;
            this.passLLabel.TabStop = true;
            this.passLLabel.Text = "Password:";
            this.passLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.passLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.passLLabel_LinkClicked);
            // 
            // ipaddressTextbox
            // 
            this.ipaddressTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ipaddressTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipaddressTextbox.Location = new System.Drawing.Point(189, 262);
            this.ipaddressTextbox.Name = "ipaddressTextbox";
            this.ipaddressTextbox.Size = new System.Drawing.Size(153, 26);
            this.ipaddressTextbox.TabIndex = 5;
            this.ipaddressTextbox.Text = "184.154.225.11";
            // 
            // portTextbox
            // 
            this.portTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.portTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextbox.Location = new System.Drawing.Point(189, 294);
            this.portTextbox.Name = "portTextbox";
            this.portTextbox.Size = new System.Drawing.Size(153, 26);
            this.portTextbox.TabIndex = 6;
            this.portTextbox.Text = "3306";
            // 
            // userTextbox
            // 
            this.userTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextbox.Location = new System.Drawing.Point(187, 358);
            this.userTextbox.Name = "userTextbox";
            this.userTextbox.Size = new System.Drawing.Size(153, 26);
            this.userTextbox.TabIndex = 7;
            this.userTextbox.Text = "teamchro_user";
            // 
            // passTextbox
            // 
            this.passTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTextbox.Location = new System.Drawing.Point(187, 390);
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.PasswordChar = '*';
            this.passTextbox.Size = new System.Drawing.Size(153, 26);
            this.passTextbox.TabIndex = 8;
            this.passTextbox.Text = "chrono";
            // 
            // applyButton
            // 
            this.applyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.applyButton.Location = new System.Drawing.Point(267, 422);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.Apply_Click);
            // 
            // databaseTextbox
            // 
            this.databaseTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.databaseTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTextbox.Location = new System.Drawing.Point(187, 326);
            this.databaseTextbox.Name = "databaseTextbox";
            this.databaseTextbox.Size = new System.Drawing.Size(153, 26);
            this.databaseTextbox.TabIndex = 11;
            this.databaseTextbox.Text = "teamchro_LATSQL";
            // 
            // databaseLLabel
            // 
            this.databaseLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.databaseLLabel.AutoSize = true;
            this.databaseLLabel.BackColor = System.Drawing.Color.Transparent;
            this.databaseLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseLLabel.ForeColor = System.Drawing.Color.White;
            this.databaseLLabel.LinkColor = System.Drawing.Color.White;
            this.databaseLLabel.Location = new System.Drawing.Point(100, 326);
            this.databaseLLabel.Name = "databaseLLabel";
            this.databaseLLabel.Size = new System.Drawing.Size(83, 20);
            this.databaseLLabel.TabIndex = 10;
            this.databaseLLabel.TabStop = true;
            this.databaseLLabel.Text = "Database:";
            this.databaseLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.databaseLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.databaseLLabel_LinkClicked);
            // 
            // appSettingsLabel
            // 
            this.appSettingsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.appSettingsLabel.AutoSize = true;
            this.appSettingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.appSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appSettingsLabel.ForeColor = System.Drawing.Color.White;
            this.appSettingsLabel.Location = new System.Drawing.Point(183, 26);
            this.appSettingsLabel.Name = "appSettingsLabel";
            this.appSettingsLabel.Size = new System.Drawing.Size(174, 24);
            this.appSettingsLabel.TabIndex = 12;
            this.appSettingsLabel.Text = "Application Settings";
            // 
            // showCurrentEmployeesCheckbox
            // 
            this.showCurrentEmployeesCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.showCurrentEmployeesCheckbox.AutoSize = true;
            this.showCurrentEmployeesCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.showCurrentEmployeesCheckbox.ForeColor = System.Drawing.Color.White;
            this.showCurrentEmployeesCheckbox.Location = new System.Drawing.Point(189, 68);
            this.showCurrentEmployeesCheckbox.Name = "showCurrentEmployeesCheckbox";
            this.showCurrentEmployeesCheckbox.Size = new System.Drawing.Size(144, 17);
            this.showCurrentEmployeesCheckbox.TabIndex = 13;
            this.showCurrentEmployeesCheckbox.Text = "Show Current Employees";
            this.showCurrentEmployeesCheckbox.UseVisualStyleBackColor = false;
            // 
            // showPreviousEmployeesCheckbox
            // 
            this.showPreviousEmployeesCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.showPreviousEmployeesCheckbox.AutoSize = true;
            this.showPreviousEmployeesCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.showPreviousEmployeesCheckbox.ForeColor = System.Drawing.Color.White;
            this.showPreviousEmployeesCheckbox.Location = new System.Drawing.Point(189, 102);
            this.showPreviousEmployeesCheckbox.Name = "showPreviousEmployeesCheckbox";
            this.showPreviousEmployeesCheckbox.Size = new System.Drawing.Size(151, 17);
            this.showPreviousEmployeesCheckbox.TabIndex = 14;
            this.showPreviousEmployeesCheckbox.Text = "Show Previous Employees";
            this.showPreviousEmployeesCheckbox.UseVisualStyleBackColor = false;
            // 
            // saveAppSettings
            // 
            this.saveAppSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveAppSettings.Location = new System.Drawing.Point(258, 125);
            this.saveAppSettings.Name = "saveAppSettings";
            this.saveAppSettings.Size = new System.Drawing.Size(75, 23);
            this.saveAppSettings.TabIndex = 15;
            this.saveAppSettings.Text = "Save";
            this.saveAppSettings.UseVisualStyleBackColor = true;
            this.saveAppSettings.Click += new System.EventHandler(this.saveAppSettings_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Los_Alamos_Timeclock.Properties.Resources._1287421014661;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.saveAppSettings);
            this.Controls.Add(this.showPreviousEmployeesCheckbox);
            this.Controls.Add(this.showCurrentEmployeesCheckbox);
            this.Controls.Add(this.appSettingsLabel);
            this.Controls.Add(this.databaseTextbox);
            this.Controls.Add(this.databaseLLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.passTextbox);
            this.Controls.Add(this.userTextbox);
            this.Controls.Add(this.portTextbox);
            this.Controls.Add(this.ipaddressTextbox);
            this.Controls.Add(this.passLLabel);
            this.Controls.Add(this.userLLabel);
            this.Controls.Add(this.portLLabel);
            this.Controls.Add(this.ipaddressLLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(500, 465);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.LinkLabel ipaddressLLabel;
        private System.Windows.Forms.LinkLabel portLLabel;
        private System.Windows.Forms.LinkLabel userLLabel;
        private System.Windows.Forms.LinkLabel passLLabel;
        private System.Windows.Forms.TextBox ipaddressTextbox;
        private System.Windows.Forms.TextBox portTextbox;
        private System.Windows.Forms.TextBox userTextbox;
        private System.Windows.Forms.TextBox passTextbox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TextBox databaseTextbox;
        private System.Windows.Forms.LinkLabel databaseLLabel;
        private System.Windows.Forms.Label appSettingsLabel;
        private System.Windows.Forms.CheckBox showCurrentEmployeesCheckbox;
        private System.Windows.Forms.CheckBox showPreviousEmployeesCheckbox;
        private System.Windows.Forms.Button saveAppSettings;

    }
}
