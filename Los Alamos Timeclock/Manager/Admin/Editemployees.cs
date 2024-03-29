﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using Los_Alamos_Timeclock.UI;

namespace Los_Alamos_Timeclock.Manager.Admin
{
    public partial class Editemployees : UserControl
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

        public static string id;
        public static TerminationConsole t = new TerminationConsole();
        Boolean terminated = false;

        public Editemployees()
        {
            InitializeComponent();

            //sets the background image if it's settings
            try
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.backgroundImage);
            }
            catch (Exception)
            {
                this.BackgroundImage = Properties.Resources._1287421014661;
            }

            //event handlers to reset the idle timer
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            fNameTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            mNameTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            lNameTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            ssnTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            aLine1Textbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            aLine2Textbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            aCityTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            aZipTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            phoneTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            emailTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            payTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            userTextbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            pass1Textbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);
            pass2Textbox.KeyDown += new KeyEventHandler(Main.maininstance.notIdle_event);

            //sets the items in the employee drop down list to main's employee list
            employeeDropdownlist.DisplayMember = "getname";
            employeeDropdownlist.ValueMember = "gid";
            employeeDropdownlist.DataSource = Main.employeeList;
            //if the employee list isn't empty, get the employee's info
            if (Main.employeeList.Count > 0)
            {
                fieldUpdate();
            }

            phoneTextbox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            //sets the jobBox's contents to main's joblist
            jobsBox.DisplayMember = "getname";
            jobsBox.ValueMember = "getpay";
            jobsBox.DataSource = Main.joblist;
        }

        //method for if the user changes the selected employee
        private void employeeDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = employeeDropdownlist.SelectedValue.ToString();
            fieldUpdate();
        }


        //method to update the fields whenever the selected employee is changed/altered
        public void fieldUpdate()
        {
            try
            {
                Main.myConnection.Open();
                Main.maininstance.sqlReader("SELECT a.*,b.*,c.ID AS Admin, d.ID AS Manager " +
                                            "FROM Employee a " +
                                            "JOIN Users b " +
                                            "ON a.ID=b.ID " +
                                            "LEFT JOIN Admin c " +
                                            "ON a.ID=c.ID " +
                                            "LEFT JOIN Manager d " +
                                            "ON a.ID=d.ID " +
                                            "WHERE a.ID='" + id + "'");

                fNameTextbox.Text = Main.reader["FName"].ToString();
                mNameTextbox.Text = Main.reader["MName"].ToString();
                lNameTextbox.Text = Main.reader["LName"].ToString();


                ssnTextbox.Text = Main.maininstance.crypt.Decrypt(Main.reader["SSN"].ToString(), "dR.wH0iS", "tlm3L0rd");


                if (Main.reader["EDate"].ToString() == "")
                {
                    employedLabel.Text = "Employed: " + DateTime.Parse(Main.reader["SDate"].ToString()).ToShortDateString() + " - Present";
                    terminated = false;
                }
                else
                {
                    employedLabel.Text = "Employed: " + DateTime.Parse(Main.reader["SDate"].ToString()).ToShortDateString() + " - " + DateTime.Parse(Main.reader["EDate"].ToString()).ToShortDateString() + "\nCondition: " + Main.reader["EReason"].ToString();
                    terminated = true;
                }

                aLine1Textbox.Text = Main.reader["Address1"].ToString();
                aLine2Textbox.Text = Main.reader["Address2"].ToString();
                aCityTextbox.Text = Main.reader["City"].ToString();
                aStateDropdownlist.Text = Main.reader["State"].ToString();
                aZipTextbox.Text = Main.reader["Zip"].ToString();

                phoneTextbox.Text = Main.reader["Phone"].ToString();
                emailTextbox.Text = Main.reader["Email"].ToString();


                if (Main.reader["Admin"].ToString() != "")
                {
                    privDropdownlist.SelectedItem = "Admin";
                }
                else if (Main.reader["Manager"].ToString() != "")
                {
                    privDropdownlist.SelectedItem = "Manager";
                }
                else
                {
                    privDropdownlist.SelectedItem = "None";
                }


                userTextbox.Text = Main.reader["User"].ToString();
                pass1Textbox.Text = "";
                pass2Textbox.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Failed to update fields");
            }
            finally
            {
                Main.myConnection.Close();
            }

            if (terminated)
            {
                quitorfireButton.Text = "Rehire";
            }
            else
            {
                quitorfireButton.Text = "Quit/Fire";
            }

        }

        //method to save the employee
        private void Saveemployee_Click(object sender, EventArgs e)
        {
            if (Main.employeeList.Count == 0)
            {
                MessageBox.Show("No Employee Selected");
            }
            else
            {
                if (validateinfo())
                {
                    try
                    {
                        Boolean a = false, m = false;

                        Main.myConnection.Open();
                        Main.maininstance.sqlReader("SELECT a.ID, b.ID AS Manager, c.ID as Admin " +
                                                    "FROM Employee a " +
                                                    "LEFT JOIN Manager b " +
                                                    "ON b.ID=a.ID " +
                                                    "LEFT JOIN Admin c " +
                                                    "ON c.ID=a.ID " +
                                                    "WHERE a.ID='" + id + "'"
                                                    );
                        if (Main.reader["Manager"].ToString() != "")
                        {
                            m = true;
                        }
                        else if (Main.reader["Admin"].ToString() != "")
                        {
                            a = true;
                        }
                        Main.reader.Close();
                        Main.myConnection.Close();

                        if (privDropdownlist.Text == "Admin")
                        {

                            if (m)
                            {
                                Main.maininstance.sqlCommand("DELETE FROM Manager WHERE ID='" + id + "'");
                            }
                            if (!a)
                            {
                                try
                                {
                                    Main.myConnection.Open();
                                    MySqlCommand command = new MySqlCommand("INSERT INTO Admin Values('" + id + "')", Main.myConnection);
                                    command.ExecuteNonQuery();
                                }
                                catch (Exception f)
                                {
                                    MessageBox.Show(f.ToString());
                                }
                                finally
                                {
                                    Main.myConnection.Close();
                                }
                            }
                        }
                        else if (privDropdownlist.Text == "Manager")
                        {
                            if (a)
                            {
                                Main.maininstance.sqlCommand("DELETE FROM Admin WHERE ID='" + id + "'");
                            }
                            if (!m)
                            {

                                try
                                {
                                    Main.myConnection.Open();
                                    MySqlCommand command = new MySqlCommand("INSERT INTO Manager Values('" + id + "')", Main.myConnection);
                                    command.ExecuteNonQuery();
                                }
                                catch (Exception f)
                                {
                                    MessageBox.Show(f.ToString());
                                }
                                finally
                                {
                                    Main.myConnection.Close();
                                }
                            }
                        }
                        else if (privDropdownlist.Text == "None")
                        {
                            Main.maininstance.sqlCommand("DELETE FROM Admin WHERE ID='" + id + "'");
                            Main.maininstance.sqlCommand("DELETE FROM Manager WHERE ID='" + id + "'");
                        }

                        Main.maininstance.sqlCommand("UPDATE Employee SET LName='" + lNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', MName='" + mNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', FName='" + fNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', SSN='" + Main.maininstance.crypt.Encrypt(ssnTextbox.Text, "dR.wH0iS", "tlm3L0rd") + "', Phone='" + phoneTextbox.Text + "', Email='" + emailTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', Address1='" + aLine1Textbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', Address2='" + aLine2Textbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', City='" + aCityTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', State='" + aStateDropdownlist.Text + "', Zip='" + aZipTextbox.Text + "' WHERE ID='" + id + "'");
                        MessageBox.Show("Employee Updated");
                        Log.writeLog(Main.eName + " edited employee: \n" + "LName= " + lNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " MName= " + mNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " FName= " + fNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\n SSN= " + Main.maininstance.crypt.Encrypt(ssnTextbox.Text, "dR.wH0iS", "tlm3L0rd") + "\n Phone= " + phoneTextbox.Text + "\n Email= " + emailTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\n Address1= " + aLine1Textbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\n Address2= " + aLine2Textbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\n City= " + aCityTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "\n State= " + aStateDropdownlist.Text + "\n Zip= " + aZipTextbox.Text + "\n Priv= " + privDropdownlist.Text);
                        Main.employeeList = Main.maininstance.getEmployees();
                        employeeDropdownlist.DataSource = Main.employeeList;
                    }

                    finally
                    {
                        Main.myConnection.Close();
                    }
                }
            }
        }

        //method to validate that all the information entered is valid, returns true if it is, otherwise false
        public Boolean validateinfo()
        {
            if (id == Main.id && Main.permissions != privDropdownlist.Text)
            {
                MessageBox.Show("You cannot change your own privileges");
                return false;
            }
            else if (fNameTextbox.Text == "")
            {
                MessageBox.Show("First Name cannot be empty");
                return false;
            }
            else if (mNameTextbox.Text == "")
            {
                MessageBox.Show("Middle Name cannot be empty");
                return false;
            }
            else if (lNameTextbox.Text == "")
            {
                MessageBox.Show("Last Name cannot be empty");
                return false;
            }
            else if (ssnTextbox.Text == "")
            {
                MessageBox.Show("SSN cannot be empty");
                return false;
            }
            else if (phoneTextbox.Text == "")
            {
                MessageBox.Show("Phone Number cannot be empty");
                return false;
            }
            else
            {
                return true;
            }
        }

        //method to take the user to the new employee screen to add a new employee
        private void Newemployee_Click(object sender, EventArgs e)
        {
            Main.maininstance.panel1.Controls.Clear();
            Main.maininstance.panel1.Controls.Add(new Newemployee(false));
            Main.maininstance.panel1.Controls[0].Dock = DockStyle.Fill;
        }

        //method to change the login information for the selected user
        private void Changelogin_Click(object sender, EventArgs e)
        {
            if (Main.employeeList.Count == 0)
            {
                MessageBox.Show("No Employee Selected");
            }
            else
            {
                try
                {
                    if (pass1Textbox.Text == pass2Textbox.Text && userTextbox.Text != "")
                    {
                        Main.myConnection.Open();
                        Main.maininstance.sqlReader("Select * FROM Users WHERE Lower(User)=Lower('" + userTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "') AND ID!='" + id + "'");
                        Boolean rows = Main.reader.HasRows;
                        Main.reader.Close();
                        if (!rows)
                        {

                            Main.maininstance.sqlReader("Select * FROM Users WHERE ID='" + id + "'");
                            rows = Main.reader.HasRows;
                            Main.reader.Close();
                            Main.myConnection.Close();

                            if (rows)
                            {
                                Main.maininstance.sqlCommand("UPDATE Users SET User='" + userTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', Password= '" + Main.maininstance.crypt.ComputeHash(pass1Textbox.Text, "Tlm3AnDR3|aTIv3DlmEn5l0nlN5pA[3", Cryptography.HashName.SHA256) + "' WHERE ID='" + id.Replace(@"\", @"\\").Replace("'", @"\'") + "'");
                            }
                            else
                            {
                                Main.maininstance.sqlCommand("INSERT INTO Users (`ID`,`User`,`Password`) Values('" + id + "', '" + userTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "','" + Main.maininstance.crypt.ComputeHash(pass1Textbox.Text, "Tlm3AnDR3|aTIv3DlmEn5l0nlN5pA[3", Cryptography.HashName.SHA256) + "')");
                            }
                            MessageBox.Show("Login Updated");
                            Log.writeLog(Main.eName + " changed login for " + fNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " " + mNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " " + lNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + ": \n" + "User= " + userTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'"));
                        }
                        else
                        {
                            MessageBox.Show("Username already exists");
                            Main.myConnection.Close();
                        }
                    }
                }
                finally
                {
                    Main.myConnection.Close();
                }
            }
        }

        //method that updates the job information when the user changes the selected job
        private void Jobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Main.myConnection.Open();

                //if the user has an entry in the database with custom pay, use that
                //otherwise use the default pay
                Main.maininstance.sqlReader("SELECT JPay FROM `Employee Jobs` WHERE ID='" + id + "' AND JID='" + jobsBox.Text + "'");
                if (!Main.reader.HasRows)
                {
                    payTextbox.Text = jobsBox.SelectedValue.ToString();
                }
                else
                {
                    payTextbox.Text = Main.reader["JPay"].ToString();
                }
            }
            finally
            {
                Main.myConnection.Close();
            }

        }

        //method to save pay changes
        private void Savepay_Click(object sender, EventArgs e)
        {
            if (Main.employeeList.Count == 0)
            {
                MessageBox.Show("No Employee Selected");
            }
            else
            {
                Decimal a;
                if (jobsBox.Text == "" || !Decimal.TryParse(payTextbox.Text, out a))
                {
                    if (jobsBox.Text == "")
                    {
                        MessageBox.Show("Please select a job");
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid pay ammount");
                    }
                }
                else
                {

                    Decimal opay = Decimal.Parse(jobsBox.SelectedValue.ToString());
                    Decimal npay = Decimal.Parse(payTextbox.Text);

                    if (opay > npay)
                    {
                        MessageBox.Show("Entered pay is below " + jobsBox.Text + "'s minimum wage");
                    }
                    else
                    {
                        Main.myConnection.Open();
                        Main.maininstance.sqlReader("SELECT * FROM `Employee Jobs` WHERE ID='" + id + "' AND JID='" + jobsBox.Text + "'");

                        if (Main.reader.HasRows)
                        {
                            Main.reader.Close();
                            Main.myConnection.Close();
                            Main.maininstance.sqlCommand("UPDATE `Employee Jobs` SET JPay='" + payTextbox.Text + "' WHERE ID='" + id + "' AND JID='" + jobsBox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "'");
                        }
                        else
                        {
                            Main.myConnection.Close();
                            Main.maininstance.sqlCommand("INSERT INTO `Employee Jobs` Values('" + id + "','" + jobsBox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "', '" + payTextbox.Text + "')");
                        }
                        MessageBox.Show("Pay Updated");
                        Log.writeLog(Main.eName + " changed payrate for " + fNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " " + mNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " " + lNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + ": \n" + "Job= " + jobsBox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " Pay= " + payTextbox.Text);
                    }
                }
            }
        }


        //method that fires whenever the quit/fire/rehire button is clicked
        private void quitorfireButton_Click(object sender, EventArgs e)
        {
            if (Main.employeeList.Count == 0)
            {
                MessageBox.Show("No Employee Selected");
            }
            else
            {
                //if the employee was already terminated it will rehire the employee
                if (terminated)
                {
                    //asks if the user is sure they want to fire them
                    DialogResult result = MessageBox.Show("Are you sure you want to rehire " +
                                                            fNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " " +
                                                            mNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + " " +
                                                            lNameTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'") + "?",
                                                            "Rehire Employee?", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Main.maininstance.sqlCommand("UPDATE Employee SET EDate=NULL,EReason=NULL WHERE ID='" + id + "'");
                        Main.maininstance.sqlCommand("INSERT INTO EmployeeNotes VALUES('" + id + "','" + Main.eName.Replace(@"\", @"\\").Replace("'", @"\'") + "',NOW(),'Rehired')");
                        Log.writeLog(Main.eName + " rehired employee: \n " + fNameTextbox.Text + " " + mNameTextbox.Text + " " + lNameTextbox.Text + "\n ID= " + id);
                        Main.employeeList = Main.maininstance.getEmployees();
                        employeeDropdownlist.DataSource = Main.employeeList;
                    }
                }
                    //else quit/fire the employee through the termination console
                else
                {
                    //if the user id is the same as the employee to be fired it tells them they can't fire themselves
                    if (id == Main.id)
                    {
                        MessageBox.Show("You cannot terminate yourself");
                    }
                    else
                    {
                        if (!t.Visible)
                        {
                            t = new TerminationConsole();
                            t.Show();
                        }
                        else
                        {
                            t.BringToFront();
                        }
                    }
                }
            }
        }
    }
}
