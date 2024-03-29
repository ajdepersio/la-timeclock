﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Los_Alamos_Timeclock.UI;




namespace Los_Alamos_Timeclock
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

    public partial class Settings : UserControl
    {

        public Settings()
        {
            InitializeComponent();

            //sets the background image
            try
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.backgroundImage);
            }
            catch (Exception)
            {
                this.BackgroundImage = Properties.Resources._1287421014661;
            }

            //events that reset the idle timer
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            ipaddressTextbox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            ipaddressTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event);
            databaseTextbox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            databaseTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event);
            portTextbox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            portTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event);
            userTextbox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            userTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event);
            passTextbox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            passTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event);

            //fills the information
            try
            {
                ipaddressTextbox.Text = Properties.Settings.Default.IP;
                portTextbox.Text = Properties.Settings.Default.Port;
                databaseTextbox.Text = Properties.Settings.Default.Database;
                userTextbox.Text = Properties.Settings.Default.User;
                passTextbox.Text = Properties.Settings.Default.Password;
                showCurrentEmployeesCheckbox.Checked = Properties.Settings.Default.showCurrentEmployees;
                showPreviousEmployeesCheckbox.Checked = Properties.Settings.Default.showPreviousEmployees;
            }
            catch
            {
                MessageBox.Show("ERROR: Failed to retrieve settings from config file");
            }
        }

        //messageboxes to explain each item
        private void ipLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The IP Addresss is the numeric representation of the database's location on the internet, use the word localhost if using WAMP or if the database is located on this computer.");
        }

        private void portLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The Port is what path the program will take to reach the database once it reaches the IP address. Default is 3306");
        }

        private void userLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("User is the username that is used to login to the database server. WAMP's default username is root");
        }

        private void passLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Password is the password that is used to login to the database server in conjunction with the User. WAMP's default setting has no password");
        }

        private void databaseLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This is the name of the database that the program will store it's information in.");
        }

        //tries to apply and save the new connection information
        private void Apply_Click(object sender, EventArgs e)
        {

            Main.myConnection = new MySqlConnection(
                "SERVER="+ipaddressTextbox.Text+
                ";PORT="+portTextbox.Text+
				";DATABASE="+databaseTextbox.Text+
				";UID="+userTextbox.Text+";" +
				";PASSWORD="+passTextbox.Text+";");

            //tries to connect to the database, if successful, it will alert the user and update the settings
            try
            {
                Main.myConnection.Open();
                MessageBox.Show("Connection Successful, the program will now exit");
                Properties.Settings.Default.IP = ipaddressTextbox.Text;
                Properties.Settings.Default.Port = portTextbox.Text;
                Properties.Settings.Default.Database = databaseTextbox.Text;
                Properties.Settings.Default.User = userTextbox.Text;
                Properties.Settings.Default.Password = passTextbox.Text;
                Properties.Settings.Default.Save();
                Environment.Exit(0);
                
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Failed to connect using new settings, restoring previous settings");
            }
            finally
            {
                Main.myConnection.Close();
            }
        }

        //Save the application settings
        private void saveAppSettings_Click(object sender, EventArgs e)
        {
            if (!showPreviousEmployeesCheckbox.Checked && !showCurrentEmployeesCheckbox.Checked)
            {
                MessageBox.Show("Must show at least 1 group of Employees");
            }
            else
            {
                Properties.Settings.Default.showCurrentEmployees = showCurrentEmployeesCheckbox.Checked;
                Properties.Settings.Default.showPreviousEmployees = showPreviousEmployeesCheckbox.Checked;
                Properties.Settings.Default.Save();
                Main.employeeList= Main.maininstance.getEmployees();
                MessageBox.Show("Application Settings Saved");
            }
        }

        //runs the cleanup utility, giving the user the options to cleanup old employees, schedules, and hours worked
        private void cleanupButton_Click(object sender, EventArgs e)
        {
            if (!Main.clup.Visible)
            {
                Main.clup = new Cleanup();
                Main.clup.Show();
            }
            else
            {
                Main.clup.BringToFront();
            }
        }

        //starts the colorSchemeChooser, allowing the user to select their own custom colors
        private void changeColorScheme_Click(object sender, EventArgs e)
        {

            if (!Main.colorChanger.Visible)
            {
                Main.colorChanger = new colorSchemeChooser();
                Main.colorChanger.Show();
            }
            else
            {
                Main.colorChanger.BringToFront();
            }

        }

        //allows the user to change the folder that the program stores it's information in
        private void changeJobFolderButton_Click(object sender, EventArgs e)
        {
            Main.changeFolder();
        }
    }
}
