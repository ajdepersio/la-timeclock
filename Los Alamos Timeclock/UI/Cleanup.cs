﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Los_Alamos_Timeclock.UI
{
    public partial class Cleanup : Form
    {
        public Cleanup()
        {
            InitializeComponent();
            beforeCalander.MaxDate = DateTime.Today;
            beforeCalander.Value = DateTime.Today.AddMonths(-1);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (requestsCheckbox.Checked || schedulecheckBox.Checked || hoursWorkedCheckbox.Checked || employeesCheckbox.Checked)
            {
                DialogResult answer = MessageBox.Show("Are you sure you wish to delete the selected items? This action cannot be undone", "Delete Selected Items?", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    String Message = "";
                    String deleted="";
                    if (requestsCheckbox.Checked)
                    {
                        Message += "DELETE FROM Requests WHERE EDate<='" + beforeCalander.Value.ToString("yyyy-MM-dd") + "';\n";
                        deleted+="Requests, ";
                    }
                    if (schedulecheckBox.Checked)
                    {
                        Message += "DELETE FROM Schedule WHERE Date<='" + beforeCalander.Value.ToString("yyyy-MM-dd") + "';\n";
                        deleted+="Schedule, ";
                    }
                    if (hoursWorkedCheckbox.Checked)
                    {
                        Message += "DELETE FROM `Hours Worked` WHERE Date<='" + beforeCalander.Value.ToString("yyyy-MM-dd") + "';\n";
                        deleted+="Hours Worked, ";
                    }
                    if (employeesCheckbox.Checked)
                    {
                        Message += "DELETE FROM Employee WHERE EDate<='" + beforeCalander.Value.ToString("yyyy-MM-dd") + "';\n";
                        deleted+="Employees, ";
                    }
                    Main.maininstance.sqlCommand(Message);

                    Log.writeLog(Main.eName + " deleted " + deleted + " before " + beforeCalander.Value.ToShortDateString());
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nothing selected to delete");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (employeesCheckbox.Checked)
            {
                DialogResult answer = MessageBox.Show("Deleting employees will also delete all information related to them (Requests, Schedule, Hours Worked, Login Information)\n" +
                    "\n Are You Sure you wish to delete employees who's last day was before the selected date?", "Delete Employees?", MessageBoxButtons.YesNo);
                if (answer != DialogResult.Yes)
                {
                    employeesCheckbox.Checked = false;
                }
            }
        }


        
    }
}
