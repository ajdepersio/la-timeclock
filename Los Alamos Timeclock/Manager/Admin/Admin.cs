﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Los_Alamos_Timeclock.Manager.Admin;
using Los_Alamos_Timeclock.Manager;

namespace Los_Alamos_Timeclock
{
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
            if (Main.permissions == "Manager")
            {
                editemployees.BackColor = Color.Gray;
                editjobs.BackColor = Color.Gray;
                calculatepay.BackColor = Color.Gray;
                viewlog.BackColor = Color.Gray;
                config.BackColor = Color.Gray;

            }
        }

        private void editemployees_Click(object sender, EventArgs e)
        {
            if (Main.permissions == "Admin")
            {
                Main.maininstance.panel1.Controls.Clear();
                Main.maininstance.panel1.Controls.Add(new Editemployees());
                Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void Paychecks_Click(object sender, EventArgs e)
        {
            if (Main.permissions == "Admin")
            {
                Main.maininstance.panel1.Controls.Clear();
                Main.maininstance.panel1.Controls.Add(new Paychecks());
                Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void config_Click(object sender, EventArgs e)
        {
            if (Main.permissions == "Admin")
            {
                Main.maininstance.panel1.Controls.Clear();
                Main.maininstance.panel1.Controls.Add(new Settings());
                Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void Editschedule_Click(object sender, EventArgs e)
        {
            Main.maininstance.panel1.Controls.Clear();
            Main.maininstance.panel1.Controls.Add(new Makesched());
            Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
        }

        private void editjobs_Click(object sender, EventArgs e)
        {
            if (Main.permissions == "Admin")
            {
                Main.maininstance.panel1.Controls.Clear();
                Main.maininstance.panel1.Controls.Add(new EditJobs());
                Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void viewlog_Click(object sender, EventArgs e)
        {
            if (Main.permissions == "Admin")
            {
                Main.maininstance.panel1.Controls.Clear();
                Main.maininstance.panel1.Controls.Add(new ViewLog());
                Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.maininstance.panel1.Controls.Clear();
            Main.maininstance.panel1.Controls.Add(new Status());
            Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
        }
    }
}
