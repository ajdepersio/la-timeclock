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

        /*
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
     */

    public partial class TerminationConsole : Form
    {
        string id = Editemployees.id;
        public TerminationConsole()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            this.MouseMove += new MouseEventHandler(Main.maininstance.notIdle_event);
            commentsTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            commentsTextbox.MouseMove += new MouseEventHandler(Main.maininstance.notIdle_event);

            reasonDropdownlist.SelectedIndex = 0;
            lastDayCalander.MinDate = DateTime.Today;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void terminateButton_Click(object sender, EventArgs e)
        {
            if (Main.permissions == "Admin")
            {
                Main.maininstance.sqlCommand("UPDATE Employee SET EDate='" + lastDayCalander.Value.ToString("yyyy-MM-dd") + "', EReason='" + reasonDropdownlist.Text + "' WHERE ID='" + id + "'");
                String logString = reasonDropdownlist.Text.ToUpper() + ": " + commentsTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\nLast Day: " + lastDayCalander.Value.ToShortDateString();
                Main.maininstance.sqlCommand("INSERT INTO EmployeeNotes VALUES('" + id + "','" + Main.eName.Replace(@"\", @"\\").Replace("'", @"\'") + "', NOW() ,'" + logString.Replace(@"\", @"\\").Replace("'", @"\'") + "')");
                Main.maininstance.sqlCommand("DELETE FROM Schedule WHERE ID='" + id + "' and Date>'" + lastDayCalander.Value.ToString("yyyy-MM-dd") + "'");

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
            else
            {
                MessageBox.Show("Not an admin");
                this.Close();
            }
        }
    }
}
