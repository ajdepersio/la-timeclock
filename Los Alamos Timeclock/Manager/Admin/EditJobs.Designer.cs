﻿namespace Los_Alamos_Timeclock.Manager.Admin
{
    partial class EditJobs
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
            System.Windows.Forms.Label nlabel;
            System.Windows.Forms.Label plabel;
            System.Windows.Forms.Label imageLabel;
            System.Windows.Forms.PictureBox pictureBox1;
            System.Windows.Forms.PictureBox pictureBox2;
            this.jobsBox = new System.Windows.Forms.ListBox();
            this.jobnameTextbox = new System.Windows.Forms.TextBox();
            this.updatejobButton = new System.Windows.Forms.Button();
            this.newjobButton = new System.Windows.Forms.Button();
            this.deletejobButton = new System.Windows.Forms.Button();
            this.tippedBox = new System.Windows.Forms.CheckBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.filenameTextbox = new System.Windows.Forms.TextBox();
            this.jobPicturebox = new System.Windows.Forms.PictureBox();
            this.payChooser = new System.Windows.Forms.NumericUpDown();
            nlabel = new System.Windows.Forms.Label();
            plabel = new System.Windows.Forms.Label();
            imageLabel = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payChooser)).BeginInit();
            this.SuspendLayout();
            // 
            // nlabel
            // 
            nlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            nlabel.AutoSize = true;
            nlabel.BackColor = System.Drawing.Color.Transparent;
            nlabel.Location = new System.Drawing.Point(178, 86);
            nlabel.Name = "nlabel";
            nlabel.Size = new System.Drawing.Size(58, 13);
            nlabel.TabIndex = 1;
            nlabel.Text = "Job Name:";
            // 
            // plabel
            // 
            plabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            plabel.AutoSize = true;
            plabel.BackColor = System.Drawing.Color.Transparent;
            plabel.Location = new System.Drawing.Point(170, 112);
            plabel.Name = "plabel";
            plabel.Size = new System.Drawing.Size(67, 13);
            plabel.TabIndex = 2;
            plabel.Text = "Starting Pay:";
            // 
            // imageLabel
            // 
            imageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            imageLabel.AutoSize = true;
            imageLabel.BackColor = System.Drawing.Color.Transparent;
            imageLabel.Location = new System.Drawing.Point(198, 161);
            imageLabel.Name = "imageLabel";
            imageLabel.Size = new System.Drawing.Size(39, 13);
            imageLabel.TabIndex = 11;
            imageLabel.Text = "Image:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.Image = global::Los_Alamos_Timeclock.Properties.Resources.dancing_cactus;
            pictureBox1.Location = new System.Drawing.Point(0, 288);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(104, 112);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 65;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox2.Image = global::Los_Alamos_Timeclock.Properties.Resources.dancing_cactus;
            pictureBox2.Location = new System.Drawing.Point(396, 288);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(104, 112);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 66;
            pictureBox2.TabStop = false;
            // 
            // jobsBox
            // 
            this.jobsBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.jobsBox.BackColor = global::Los_Alamos_Timeclock.Properties.Settings.Default.tableBackgroundColor;
            this.jobsBox.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Los_Alamos_Timeclock.Properties.Settings.Default, "tableBackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.jobsBox.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Los_Alamos_Timeclock.Properties.Settings.Default, "tableTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.jobsBox.ForeColor = global::Los_Alamos_Timeclock.Properties.Settings.Default.tableTextColor;
            this.jobsBox.FormattingEnabled = true;
            this.jobsBox.Location = new System.Drawing.Point(350, 83);
            this.jobsBox.Name = "jobsBox";
            this.jobsBox.Size = new System.Drawing.Size(136, 147);
            this.jobsBox.TabIndex = 0;
            this.jobsBox.SelectedIndexChanged += new System.EventHandler(this.jobsBox_SelectedIndexChanged);
            // 
            // jobnameTextbox
            // 
            this.jobnameTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.jobnameTextbox.Location = new System.Drawing.Point(243, 83);
            this.jobnameTextbox.Name = "jobnameTextbox";
            this.jobnameTextbox.Size = new System.Drawing.Size(100, 20);
            this.jobnameTextbox.TabIndex = 1;
            // 
            // updatejobButton
            // 
            this.updatejobButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updatejobButton.ForeColor = System.Drawing.Color.Black;
            this.updatejobButton.Location = new System.Drawing.Point(132, 286);
            this.updatejobButton.Name = "updatejobButton";
            this.updatejobButton.Size = new System.Drawing.Size(75, 75);
            this.updatejobButton.TabIndex = 6;
            this.updatejobButton.Text = "Update";
            this.updatejobButton.UseVisualStyleBackColor = true;
            this.updatejobButton.Click += new System.EventHandler(this.updateJob_Click);
            // 
            // newjobButton
            // 
            this.newjobButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newjobButton.ForeColor = System.Drawing.Color.Black;
            this.newjobButton.Location = new System.Drawing.Point(213, 286);
            this.newjobButton.Name = "newjobButton";
            this.newjobButton.Size = new System.Drawing.Size(75, 75);
            this.newjobButton.TabIndex = 7;
            this.newjobButton.Text = "New";
            this.newjobButton.UseVisualStyleBackColor = true;
            this.newjobButton.Click += new System.EventHandler(this.newJob_Click);
            // 
            // deletejobButton
            // 
            this.deletejobButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deletejobButton.ForeColor = System.Drawing.Color.Black;
            this.deletejobButton.Location = new System.Drawing.Point(294, 286);
            this.deletejobButton.Name = "deletejobButton";
            this.deletejobButton.Size = new System.Drawing.Size(75, 75);
            this.deletejobButton.TabIndex = 8;
            this.deletejobButton.Text = "Delete";
            this.deletejobButton.UseVisualStyleBackColor = true;
            this.deletejobButton.Click += new System.EventHandler(this.deleteJob_Click);
            // 
            // tippedBox
            // 
            this.tippedBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tippedBox.AutoSize = true;
            this.tippedBox.BackColor = System.Drawing.Color.Transparent;
            this.tippedBox.Location = new System.Drawing.Point(242, 135);
            this.tippedBox.Name = "tippedBox";
            this.tippedBox.Size = new System.Drawing.Size(79, 17);
            this.tippedBox.TabIndex = 3;
            this.tippedBox.Text = "Tipped Job";
            this.tippedBox.UseVisualStyleBackColor = false;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectImageButton.ForeColor = System.Drawing.Color.Black;
            this.selectImageButton.Location = new System.Drawing.Point(243, 184);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(101, 23);
            this.selectImageButton.TabIndex = 5;
            this.selectImageButton.Text = "Select Image";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // filenameTextbox
            // 
            this.filenameTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filenameTextbox.Location = new System.Drawing.Point(243, 158);
            this.filenameTextbox.Name = "filenameTextbox";
            this.filenameTextbox.ReadOnly = true;
            this.filenameTextbox.Size = new System.Drawing.Size(100, 20);
            this.filenameTextbox.TabIndex = 4;
            // 
            // jobPicturebox
            // 
            this.jobPicturebox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.jobPicturebox.BackColor = global::Los_Alamos_Timeclock.Properties.Settings.Default.tableBackgroundColor;
            this.jobPicturebox.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Los_Alamos_Timeclock.Properties.Settings.Default, "tableTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.jobPicturebox.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Los_Alamos_Timeclock.Properties.Settings.Default, "tableBackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.jobPicturebox.ForeColor = global::Los_Alamos_Timeclock.Properties.Settings.Default.tableTextColor;
            this.jobPicturebox.Location = new System.Drawing.Point(15, 83);
            this.jobPicturebox.Name = "jobPicturebox";
            this.jobPicturebox.Size = new System.Drawing.Size(150, 147);
            this.jobPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jobPicturebox.TabIndex = 12;
            this.jobPicturebox.TabStop = false;
            // 
            // payChooser
            // 
            this.payChooser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.payChooser.DecimalPlaces = 2;
            this.payChooser.Location = new System.Drawing.Point(243, 110);
            this.payChooser.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.payChooser.Name = "payChooser";
            this.payChooser.Size = new System.Drawing.Size(101, 20);
            this.payChooser.TabIndex = 2;
            // 
            // EditJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Los_Alamos_Timeclock.Properties.Resources._1287421014661;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.payChooser);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(this.jobPicturebox);
            this.Controls.Add(imageLabel);
            this.Controls.Add(this.filenameTextbox);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.tippedBox);
            this.Controls.Add(this.deletejobButton);
            this.Controls.Add(this.newjobButton);
            this.Controls.Add(this.updatejobButton);
            this.Controls.Add(this.jobnameTextbox);
            this.Controls.Add(plabel);
            this.Controls.Add(nlabel);
            this.Controls.Add(this.jobsBox);
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Los_Alamos_Timeclock.Properties.Settings.Default, "textColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.ForeColor = global::Los_Alamos_Timeclock.Properties.Settings.Default.textColor;
            this.Name = "EditJobs";
            this.Size = new System.Drawing.Size(500, 400);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payChooser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox jobsBox;
        private System.Windows.Forms.TextBox jobnameTextbox;
        private System.Windows.Forms.Button updatejobButton;
        private System.Windows.Forms.Button newjobButton;
        private System.Windows.Forms.Button deletejobButton;
        private System.Windows.Forms.CheckBox tippedBox;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.TextBox filenameTextbox;
        private System.Windows.Forms.PictureBox jobPicturebox;
        private System.Windows.Forms.NumericUpDown payChooser;
    }
}
