﻿namespace Los_Alamos_Timeclock
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.menu1 = new Los_Alamos_Timeclock.Menu();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Los_Alamos_Timeclock.Properties.Resources._1287421014661;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Los_Alamos_Timeclock.Properties.Settings.Default, "textColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = global::Los_Alamos_Timeclock.Properties.Settings.Default.textColor;
            this.panel1.Location = new System.Drawing.Point(70, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 400);
            this.panel1.TabIndex = 6;
            // 
            // timeoutTimer
            // 
            this.timeoutTimer.Tick += new System.EventHandler(this.timeoutTimer_Tick);
            // 
            // menu1
            // 
            this.menu1.AutoSize = true;
            this.menu1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Margin = new System.Windows.Forms.Padding(0);
            this.menu1.MinimumSize = new System.Drawing.Size(70, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(70, 400);
            this.menu1.TabIndex = 1;
            this.menu1.Visible = false;
            this.menu1.Load += new System.EventHandler(this.menu1_Load);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Los_Alamos_Timeclock.Properties.Resources._1287421014661;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(570, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(586, 438);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Los Alamos Timeclock";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Menu menu1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timeoutTimer;





    }
}