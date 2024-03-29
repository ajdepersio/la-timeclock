﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Los_Alamos_Timeclock;
using System.Collections;
using System.Diagnostics;
using Los_Alamos_Timeclock.UI;
using System.IO;
using System.Reflection;
using Los_Alamos_Timeclock.Properties;

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



    //Main file for program

    public partial class Main : Form
    {
        public static Main maininstance = null;
        public static string id;
        public static string eName;
        public static ArrayList joblist;
        public static ArrayList employeeList;
        public static MySqlConnection myConnection = new MySqlConnection();
        public static MySqlDataReader reader;
        public static string permissions = "";
        public Cryptography crypt = new Cryptography();
        public static Cleanup clup=new Cleanup();
        public static colorSchemeChooser colorChanger;

        public Main()
        {

            InitializeComponent();

            //sets background
            try
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.backgroundImage);
            }
            catch (Exception)
            {
                this.BackgroundImage = Properties.Resources._1287421014661;
            }
            
            //defines the main instance and color chooser so it can be used when needed
            maininstance = this;
            colorChanger = new colorSchemeChooser();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                                    ControlStyles.UserPaint |
                                    ControlStyles.AllPaintingInWmPaint, true);
            timeoutTimer.Interval = 1000;

            //Starts up with login user controls
            panel1.Controls.Clear();
            panel1.Controls.Add(new Login());
            panel1.Controls[0].Dock = DockStyle.Fill;


            //sets up the folder for the program to store the job images in if it isn't set
            if (Properties.Settings.Default.jobImageFolderPath == "")
            {
                MessageBox.Show("Where would you like Los Alamos Timeclock to store it's images/log?");
                changeFolder();
            }

            //Connects to the database


            Main.myConnection = new MySqlConnection(
                "SERVER=" + Properties.Settings.Default.IP +
                ";PORT=" + Properties.Settings.Default.Port +
                ";DATABASE=" + Properties.Settings.Default.Database +
                ";UID=" + Properties.Settings.Default.User + ";" +
                ";PASSWORD=" + Properties.Settings.Default.Password + ";");

            connectDB(myConnection);

            DBInit.initTables(myConnection);
            DBInit.initAdmin(myConnection);

            joblist = getJobs();
            employeeList = getEmployees();
            menu1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notIdle_event);
        }

        /** Method to return an array of employee's IDs, lastnames, firstnames
         * 
         * @author Nate Rush
         * @return ArrayList Employees
         */
        public ArrayList getEmployees()
        {
            ArrayList employees = new ArrayList();
            try
            {
                //start SQL connection and query
                Main.myConnection.Open();
                String commandString;

                //command changes based on what the current settings are
                if (Properties.Settings.Default.showCurrentEmployees && Properties.Settings.Default.showPreviousEmployees)
                {
                    commandString = "Select ID, LName,FName From Employee ORDER BY LName";
                }
                else if (Properties.Settings.Default.showCurrentEmployees == false && Properties.Settings.Default.showPreviousEmployees)
                {
                    commandString = "Select ID, LName,FName From Employee WHERE EDate<'" + DateTime.Today.Date.ToString("yyyy-MM-dd") + "' ORDER BY LName";
                }
                else
                {
                    commandString = "Select ID, LName,FName From Employee WHERE EDate>='" + DateTime.Today.Date.ToString("yyyy-MM-dd") + "' OR EDate is NULL ORDER BY LName";
                }


                MySqlCommand command = new MySqlCommand(commandString, Main.myConnection);
                Main.reader = command.ExecuteReader();

                //Populate the arraylist
                while (Main.reader.Read())
                {
                    employees.Add(new Employee(Main.reader["LName"].ToString() + ", " + Main.reader["FName"].ToString(), int.Parse(Main.reader["ID"].ToString())));
                }

                //Close the connection
                Main.reader.Close();
                Main.myConnection.Close();
                return employees;

            }
            //If connection to Database fails
            catch (Exception)
            {
                MessageBox.Show("ERROR: Failed to fetch Employee list from database");

                return employees;
            }
            finally
            {
                myConnection.Close();
            }

        }

        /*Class to store the Employees in the Employee List*/
        public class Employee
        {
            private string Name;
            private int ID;

            /* Constructor for Employee
             * 
             * @param stringName    The name of the employee
             * @param intID         The ID number of the employee
             */
            public Employee(string stringName, int intID)
            {
                this.Name = stringName;
                this.ID = intID;
            }

            /* Return the name
             * 
             * @return string Name     Name of the employee
             */
            public string getname
            {
                get
                {
                    return Name;
                }
            }

            /* Return the ID number
             * 
             * @return int ID     ID number of the employee
             */
            public int gid
            {
                get
                {
                    return ID;
                }
            }
        }

        /* Method to return a list of jobs available
         * 
         * @author Nate Rush
         * @author Andrew DePersio
         * @lastModified 4/6/12
         * @return ArrayList joblist    List of jobs available
         *
         */
        public ArrayList getJobs()
        {
            ArrayList joblist = new ArrayList();

            try
            {
                //Connect to the database, execute query
                Main.myConnection.Open();
                MySqlCommand command = new MySqlCommand("Select * From Jobs ORDER BY JID", Main.myConnection);
                Main.reader = command.ExecuteReader();

                //Populate the arraylist with jobs
                while (Main.reader.Read())
                {
                    joblist.Add(new Job(Main.reader["JID"].ToString(), Decimal.Parse(Main.reader["JSPay"].ToString()), Boolean.Parse(Main.reader["TippedJob"].ToString())));
                }

                //Close the connection
                Main.reader.Close();
                Main.myConnection.Close();
                return joblist;
            }
            //If connection to Database fails
            catch (Exception)
            {
                MessageBox.Show("ERROR: Failed to fetch Job list from database");
                return joblist;
            }
            finally
            {
                myConnection.Close();
            }
        }

        /* Class to store object of job*/
        public class Job
        {
            private string Jobname;
            private decimal Pay;
            private Boolean Tipped;

            /* Main constructor for a Job
             * 
             * @param stringName    Name of the job
             * @param jpay          Default pay rate for the job
             * @param tipped        Whether the job is tipped or not
             */
            public Job(string stringName, decimal jpay, Boolean tipped)
            {
                this.Jobname = stringName;
                this.Pay = jpay;
                this.Tipped = tipped;
            }

            /* Method to return the name of a job
             * 
             * @return string JobName   Name of the job
             */
            public string getname
            {
                get
                {
                    return Jobname;
                }
            }

            /* Method to return the default payrate of a job
             * 
             * @return decimal Pay   Default payrate of a job
             */
            public decimal getpay
            {
                get
                {
                    return Pay;
                }
            }

            /* Method to return whether or not the job is tipped
             * 
             * @return boolean Tipped       Whether the job is tipped or not
             */
            public Boolean getTipped
            {
                get
                {
                    return Tipped;
                }
            }
        }


        /* Method to connect to the database
         * @author Nate Rush
         * @author Andrew DePersio ajdepersio@gmail.com
         * 
         * @param myConnection      The MySqlConnection server to be connected to
         */
        public void connectDB(MySqlConnection myConnection)
        {
            try
            {            
                myConnection.Open();            
            }

           //If connection fails, give user the option to reenter settings or exit the program
            catch(Exception)
            {
                DialogResult result = MessageBox.Show("Failed to connect to database, make sure MYSQL is running or change settings. \n Do you want to change connection settings?",
                    "Database Error", MessageBoxButtons.YesNo);

                //Change DB connection settings
                if (result == DialogResult.Yes)
                {
                    changeConnection();
                }
                //Or exit the program
                else
                {
                    Environment.Exit(0);
                }
            }
            finally
            {
                myConnection.Close();
            }
            
        }


        /** Method to change database connection settings in case of connection error
         * Then executes connectDB() with the new SQL connection
         * 
         * @author Andrew DePersio ajdepersio@gmail.com
         */
        public void changeConnection()
        {
            //Get input from user
            string server = Microsoft.VisualBasic.Interaction.InputBox("Enter Database IP (localhost for WAMP)", "", Properties.Settings.Default.IP);
            string port = Microsoft.VisualBasic.Interaction.InputBox("Enter Database Port (Default 3306)", "", Properties.Settings.Default.Port);
            string database = Microsoft.VisualBasic.Interaction.InputBox("Enter Database Name", "", Properties.Settings.Default.Database);
            string uid = Microsoft.VisualBasic.Interaction.InputBox("Enter Database User (root for WAMP default)", "", Properties.Settings.Default.User);
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter Database User Password (leave empty for WAMP default)", "", Properties.Settings.Default.Password);

            //Populate the default settings with the new connection info
            Properties.Settings.Default.IP = server;
            Properties.Settings.Default.Port = port;
            Properties.Settings.Default.Database = database;
            Properties.Settings.Default.User = uid;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();

            //Build new sql connection
            Main.myConnection = new MySqlConnection(
                "SERVER=" + server +
                ";PORT=" + port +
                ";DATABASE=" + database +
                ";UID=" + uid + ";" +
                ";PASSWORD=" + password + ";");

            //try to connect
            connectDB(myConnection);
        }

        /* Method to execute an SQL query command
         * 
         * @param c     The command to be executed
         */
        public void sqlCommand(String c)
        {
            try
            //Connect and execute query
            {
                myConnection.Open();
                MySqlCommand command = new MySqlCommand(c, myConnection);
                command.ExecuteNonQuery();
            }
            //if DB connection error
            catch (Exception)
            {
                MessageBox.Show("ERROR: Failed to execute SQL command");
            }
            //close the connection
            finally
            {
                myConnection.Close();
            }
        }

        /* Method to execute a select command and read the results
         * 
         * @param c     The command to be executed
         */
        public void sqlReader(String c)
        {
            c = c + " LIMIT 0,1000";
            MySqlCommand command = new MySqlCommand(c, myConnection);

            try
            {
                reader = command.ExecuteReader();
                reader.Read();
            }
            catch(Exception)
            {
                MessageBox.Show("ERROR: Failed to read from database");
            }
        }

        /* Method to round time to the nearest 15 minute interval
         * 
         * @param t                 The current time
         * @return DateTime t       The rounded time
         */
        public static DateTime roundtime(DateTime t)
        {
            //Get the current time, then the minutes of it
            TimeSpan a = TimeSpan.ParseExact(t.ToString("HH:mm:ss"), "g", null);

            int q= a.Minutes / 15;
            a = a.Subtract(TimeSpan.FromMinutes(15*q));

            if (a.Minutes >= 8)
            {
                a = TimeSpan.FromHours(a.Hours).Add(TimeSpan.FromMinutes((q * 15) + 15));
            }
            else
            {
                a = TimeSpan.FromHours(a.Hours).Add(TimeSpan.FromMinutes(q * 15));
            }

            //return the time
            t = DateTime.Parse(a.ToString());
            return t;
        }

        /* Error message showing method
         * 
         * @param s     Error message
         */
        public void error(String s)
        {
            MessageBox.Show(s);
        }

        //load the main menu
        private void Main_Load(object sender, EventArgs e)
        {
            menu1.Hide();
        }

        //start clock
        private void menu1_Load(object sender, EventArgs e)
        {
            menu1.timer1.Start();
        }



        //methods to deal with the timeout timer

        //ammount of time to wait before timing out
        private TimeSpan timeoutTimelimit = TimeSpan.FromMinutes(2);
        private DateTime timerCompareTime = DateTime.Now;
        
        //start the timer
        public void startTimer()
        {
            timerCompareTime = DateTime.Now;
            timeoutTimer.Start();
        }

        //reset the timer
        public void resetTimer()
        {
            timerCompareTime = DateTime.Now;
        }

        //stop the timer
        public void stopTimer()
        {
            timeoutTimer.Stop();
        }

        //event for the timer ticking
        private void timeoutTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(timerCompareTime) > timeoutTimelimit)
            {
                stopTimer();
                permissions = "0";
                Manager.Admin.Editemployees.t.Close();
                Manager.Admin.Makesched.l.Close();
                Clockinout.o.Close();
                clup.Close();

                maininstance.menu1.Hide();
                panel1.Controls.Clear();
                panel1.Controls.Add(new Login());
                panel1.Controls[0].Dock = DockStyle.Fill;
                MessageBox.Show("You have been logged out due to inactivity");
            }
        }

        //event that registers user inputs
        private int mX = 0, mY = 0;
        public virtual void notIdle_event(object sender, EventArgs e)
        {
            //checks if mouse has moved compared to last run, if it has reset the timer
            if (MousePosition.X != mX && MousePosition.Y != mY)
            {
                mX = MousePosition.X;
                mY = MousePosition.Y;
                resetTimer();
            }
            else if (e.ToString() == "System.Windows.Forms.KeyEventArgs")
            {
                resetTimer();
            }
        }


        //method to change the folder the program stores the log/images in
        public static void changeFolder()
        {
            FolderBrowserDialog jobFolder = new FolderBrowserDialog();

            if (jobFolder.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.Directory.Exists(jobFolder.SelectedPath + "\\Los Alamos Timeclock")==false)
                {
                    System.IO.Directory.CreateDirectory(jobFolder.SelectedPath+"\\Los Alamos Timeclock\\images");
                }

                Properties.Settings.Default.jobImageFolderPath = jobFolder.SelectedPath + "\\Los Alamos Timeclock";
                Properties.Settings.Default.Save();

                byte[] imgbytes;
                ImageConverter converter = new ImageConverter();
                //array of files that need to be saved
                String[] jobs = { "Bartender", "Cook", "Dishwasher", "Manager", "Security", "Server" };

                //saves the default job images into the selected folder
                for (int i = 0; i < jobs.Length; i++)
                {
                    try
                    {
                        imgbytes = (byte[])converter.ConvertTo(Properties.Resources.ResourceManager.GetObject(jobs[i]), typeof(byte[]));
                        File.WriteAllBytes(Properties.Settings.Default.jobImageFolderPath + "\\images\\" + jobs[i] + ".bmp", imgbytes);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("ERROR: IO Failed to write file");
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("ERROR: Problem Writing file "+jobs[i]+".bmp");
                    }
                }

            }
        }

    }
}
