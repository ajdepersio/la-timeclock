﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Los_Alamos_Timeclock.Manager.Admin;

namespace Los_Alamos_Timeclock.UI
{
    public partial class TerminationConsole : Form
    {
        string id = Editemployees.id;
        public TerminationConsole()
        {
            InitializeComponent();
            reasonDropdownlist.SelectedIndex = 0;
            lastDayCalander.MinDate = DateTime.Today;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void terminateButton_Click(object sender, EventArgs e)
        {
            Main.maininstance.sqlCommand("UPDATE Employee SET EDate='" + lastDayCalander.Value.ToString("yyyy-MM-dd") + "', EReason='" + reasonDropdownlist.Text + "' WHERE ID='" + id + "'");
            String logString = reasonDropdownlist.Text.ToUpper() + ": " + commentsTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\nLast Day: " + lastDayCalander.Value.ToShortDateString();
            Main.maininstance.sqlCommand("INSERT INTO EmployeeNotes VALUES('" + id + "','" + Main.eName.Replace(@"\", @"\\").Replace("'", @"\'") + "', NOW() ,'" + logString.Replace(@"\", @"\\").Replace("'", @"\'") + "')");

            if (removePrivCheckbox.Checked)
            {
                Main.maininstance.sqlCommand("DELETE FROM Admin WHERE ID='" + id + "'");
                Main.maininstance.sqlCommand("DELETE FROM Manager WHERE ID='" + id + "'");
            }
            Main.maininstance.getEmployees();
            MessageBox.Show("Employee Terminated");
            Main.maininstance.panel1.Controls.Clear();
            Main.maininstance.panel1.Controls.Add(new Editemployees());
            Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
            this.Close();
        }
    }
}