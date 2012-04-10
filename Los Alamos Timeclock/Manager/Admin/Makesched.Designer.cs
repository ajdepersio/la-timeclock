﻿using System.Windows.Forms;
namespace Los_Alamos_Timeclock.Manager.Admin
{
    partial class Makesched
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
            System.Windows.Forms.Label employeeLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label startLabel;
            System.Windows.Forms.Label endLabel;
            System.Windows.Forms.Label jobLabel;
            this.employeeDropdownlist = new System.Windows.Forms.ComboBox();
            this.calander = new System.Windows.Forms.DateTimePicker();
            this.updatescheduleButon = new System.Windows.Forms.Button();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.jobsDropdownlist = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.startHourDropdownlist = new System.Windows.Forms.ComboBox();
            this.startMinDropdownlist = new System.Windows.Forms.ComboBox();
            this.endHourDropdownlist = new System.Windows.Forms.ComboBox();
            this.endMinDropdownlist = new System.Windows.Forms.ComboBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.showRequests = new System.Windows.Forms.Button();
            employeeLabel = new System.Windows.Forms.Label();
            startLabel = new System.Windows.Forms.Label();
            endLabel = new System.Windows.Forms.Label();
            jobLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeDropdownlist
            // 
            this.employeeDropdownlist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.employeeDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeDropdownlist.FormattingEnabled = true;
            this.employeeDropdownlist.Location = new System.Drawing.Point(79, 267);
            this.employeeDropdownlist.Name = "employeeDropdownlist";
            this.employeeDropdownlist.Size = new System.Drawing.Size(190, 21);
            this.employeeDropdownlist.TabIndex = 0;
            this.employeeDropdownlist.SelectedIndexChanged += new System.EventHandler(this.employeeDropdownlist_SelectedIndexChanged);
            // 
            // employeeLabel
            // 
            employeeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            employeeLabel.AutoSize = true;
            employeeLabel.BackColor = System.Drawing.Color.Transparent;
            employeeLabel.ForeColor = System.Drawing.Color.White;
            employeeLabel.Location = new System.Drawing.Point(20, 269);
            employeeLabel.Name = "employeeLabel";
            employeeLabel.Size = new System.Drawing.Size(56, 13);
            employeeLabel.TabIndex = 3;
            employeeLabel.Text = "Employee:";
            // 
            // calander
            // 
            this.calander.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.calander.Location = new System.Drawing.Point(275, 267);
            this.calander.Name = "calander";
            this.calander.Size = new System.Drawing.Size(200, 20);
            this.calander.TabIndex = 1;
            this.calander.ValueChanged += new System.EventHandler(this.calander_DateChanged);
            // 
            // updatescheduleButon
            // 
            this.updatescheduleButon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.updatescheduleButon.Location = new System.Drawing.Point(275, 293);
            this.updatescheduleButon.Name = "updatescheduleButon";
            this.updatescheduleButon.Size = new System.Drawing.Size(60, 95);
            this.updatescheduleButon.TabIndex = 7;
            this.updatescheduleButon.Text = "Update";
            this.updatescheduleButon.UseVisualStyleBackColor = true;
            this.updatescheduleButon.Click += new System.EventHandler(this.update_Click);
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.datagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(0, 0);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.RowHeadersVisible = false;
            this.datagrid.Size = new System.Drawing.Size(500, 261);
            this.datagrid.TabIndex = 6;
            // 
            // jobsDropdownlist
            // 
            this.jobsDropdownlist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.jobsDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobsDropdownlist.FormattingEnabled = true;
            this.jobsDropdownlist.Location = new System.Drawing.Point(79, 368);
            this.jobsDropdownlist.Name = "jobsDropdownlist";
            this.jobsDropdownlist.Size = new System.Drawing.Size(190, 21);
            this.jobsDropdownlist.TabIndex = 6;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteButton.Location = new System.Drawing.Point(341, 293);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(66, 95);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.delete_Click);
            // 
            // startHourDropdownlist
            // 
            this.startHourDropdownlist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startHourDropdownlist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.startHourDropdownlist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.startHourDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startHourDropdownlist.FormattingEnabled = true;
            this.startHourDropdownlist.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.startHourDropdownlist.Location = new System.Drawing.Point(79, 294);
            this.startHourDropdownlist.Name = "startHourDropdownlist";
            this.startHourDropdownlist.Size = new System.Drawing.Size(92, 21);
            this.startHourDropdownlist.TabIndex = 2;
            this.startHourDropdownlist.SelectedIndexChanged += new System.EventHandler(this.startHour_SelectedIndexChanged);
            // 
            // startLabel
            // 
            startLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            startLabel.AutoSize = true;
            startLabel.BackColor = System.Drawing.Color.Transparent;
            startLabel.ForeColor = System.Drawing.Color.White;
            startLabel.Location = new System.Drawing.Point(20, 297);
            startLabel.Name = "startLabel";
            startLabel.Size = new System.Drawing.Size(32, 13);
            startLabel.TabIndex = 11;
            startLabel.Text = "Start:";
            // 
            // endLabel
            // 
            endLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            endLabel.AutoSize = true;
            endLabel.BackColor = System.Drawing.Color.Transparent;
            endLabel.ForeColor = System.Drawing.Color.White;
            endLabel.Location = new System.Drawing.Point(20, 324);
            endLabel.Name = "endLabel";
            endLabel.Size = new System.Drawing.Size(29, 13);
            endLabel.TabIndex = 12;
            endLabel.Text = "End:";
            // 
            // jobLabel
            // 
            jobLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            jobLabel.AutoSize = true;
            jobLabel.BackColor = System.Drawing.Color.Transparent;
            jobLabel.ForeColor = System.Drawing.Color.White;
            jobLabel.Location = new System.Drawing.Point(20, 368);
            jobLabel.Name = "jobLabel";
            jobLabel.Size = new System.Drawing.Size(27, 13);
            jobLabel.TabIndex = 13;
            jobLabel.Text = "Job:";
            // 
            // startMinDropdownlist
            // 
            this.startMinDropdownlist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startMinDropdownlist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.startMinDropdownlist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.startMinDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startMinDropdownlist.FormattingEnabled = true;
            this.startMinDropdownlist.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.startMinDropdownlist.Location = new System.Drawing.Point(177, 294);
            this.startMinDropdownlist.Name = "startMinDropdownlist";
            this.startMinDropdownlist.Size = new System.Drawing.Size(92, 21);
            this.startMinDropdownlist.TabIndex = 3;
            this.startMinDropdownlist.SelectedIndexChanged += new System.EventHandler(this.startMin_SelectedIndexChanged);
            // 
            // endHourDropdownlist
            // 
            this.endHourDropdownlist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.endHourDropdownlist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.endHourDropdownlist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.endHourDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endHourDropdownlist.FormattingEnabled = true;
            this.endHourDropdownlist.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.endHourDropdownlist.Location = new System.Drawing.Point(79, 321);
            this.endHourDropdownlist.Name = "endHourDropdownlist";
            this.endHourDropdownlist.Size = new System.Drawing.Size(92, 21);
            this.endHourDropdownlist.TabIndex = 4;
            this.endHourDropdownlist.SelectedIndexChanged += new System.EventHandler(this.endHour_SelectedIndexChanged);
            // 
            // endMinDropdownlist
            // 
            this.endMinDropdownlist.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.endMinDropdownlist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.endMinDropdownlist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.endMinDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endMinDropdownlist.FormattingEnabled = true;
            this.endMinDropdownlist.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.endMinDropdownlist.Location = new System.Drawing.Point(177, 321);
            this.endMinDropdownlist.Name = "endMinDropdownlist";
            this.endMinDropdownlist.Size = new System.Drawing.Size(92, 21);
            this.endMinDropdownlist.TabIndex = 5;
            this.endMinDropdownlist.SelectedIndexChanged += new System.EventHandler(this.endMin_SelectedIndexChanged);
            // 
            // lengthLabel
            // 
            this.lengthLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.lengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lengthLabel.ForeColor = System.Drawing.Color.White;
            this.lengthLabel.Location = new System.Drawing.Point(75, 345);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(67, 20);
            this.lengthLabel.TabIndex = 17;
            this.lengthLabel.Text = "Length: ";
            // 
            // showRequests
            // 
            this.showRequests.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.showRequests.Location = new System.Drawing.Point(413, 293);
            this.showRequests.Name = "showRequests";
            this.showRequests.Size = new System.Drawing.Size(62, 95);
            this.showRequests.TabIndex = 9;
            this.showRequests.Text = "Show Overview";
            this.showRequests.UseVisualStyleBackColor = true;
            this.showRequests.Click += new System.EventHandler(this.showRequests_Click);
            // 
            // Makesched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Los_Alamos_Timeclock.Properties.Resources._1287421014661;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.showRequests);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.endMinDropdownlist);
            this.Controls.Add(this.endHourDropdownlist);
            this.Controls.Add(this.startMinDropdownlist);
            this.Controls.Add(jobLabel);
            this.Controls.Add(endLabel);
            this.Controls.Add(startLabel);
            this.Controls.Add(this.startHourDropdownlist);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.jobsDropdownlist);
            this.Controls.Add(this.updatescheduleButon);
            this.Controls.Add(this.calander);
            this.Controls.Add(employeeLabel);
            this.Controls.Add(this.employeeDropdownlist);
            this.Controls.Add(this.datagrid);
            this.DoubleBuffered = true;
            this.Name = "Makesched";
            this.Size = new System.Drawing.Size(500, 400);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox employeeDropdownlist;
        private System.Windows.Forms.DateTimePicker calander;
        private System.Windows.Forms.Button updatescheduleButon;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.ComboBox jobsDropdownlist;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox startHourDropdownlist;
        private System.Windows.Forms.ComboBox startMinDropdownlist;
        private System.Windows.Forms.ComboBox endHourDropdownlist;
        private System.Windows.Forms.ComboBox endMinDropdownlist;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Button showRequests;

    }
}
