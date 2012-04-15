﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Los_Alamos_Timeclock.Manager.Admin;

namespace Los_Alamos_Timeclock
{
    class DBInit
    {
        public static MySqlConnection myConnection = new MySqlConnection();
        public static initAdmin myinitadmin = new initAdmin();
        public static void main()
        {
            //check if database exists
             myConnection = new MySqlConnection(
                "SERVER=" + Properties.Settings.Default.IP +
                ";PORT=" + Properties.Settings.Default.Port +
                ";DATABASE=" + Properties.Settings.Default.Database +
                ";UID=" + Properties.Settings.Default.User + ";" +
                ";PASSWORD=" + Properties.Settings.Default.Password + ";");

             connectDB(myConnection);
        }

        public static void connectDB(MySqlConnection myConnection)
        {

             try
             {
                 myConnection.Open();
                 myConnection.Close();
             }

             catch
             {
                 DialogResult result = MessageBox.Show("Failed to connect to database, make sure MYSQL is running or change settings. \n Do you Want to change connection settings?",
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
          }

         /** Method to change database connection settings in case of connection error
         * Then executes connectDB() with the new SQL connection
         * 
         * @author Andrew DePersio ajdepersio@gmail.com
         */
        public static void changeConnection()
        {
            //Get input from user
            string server = Microsoft.VisualBasic.Interaction.InputBox("Enter Database IP", "", Properties.Settings.Default.IP);
            string port = Microsoft.VisualBasic.Interaction.InputBox("Enter Database Port", "", Properties.Settings.Default.Port);
            string database = Microsoft.VisualBasic.Interaction.InputBox("Enter Database Name", "", Properties.Settings.Default.Database);
            string uid = Microsoft.VisualBasic.Interaction.InputBox("Enter Database User", "", Properties.Settings.Default.User);
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter Database User Password", "", Properties.Settings.Default.Password);

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
            //create database
            //create tables


        public static void initAdmin(MySqlConnection myConnection)
        {
            //create initial admin
            //check if there are no admins            
            
            myConnection.Open();
            Main.maininstance.sqlReader("select count(*) from Admin");

            if (int.Parse(Main.reader["count(*)"].ToString()) == 0)
            {
                //Alert that no admins were found, ask if they want to make one
                DialogResult result = MessageBox.Show("No Administrators were found in the Database. \r\nDo you want to create one?", "Admin Not Found" , MessageBoxButtons.YesNo);
                 
                
                if (result == DialogResult.Yes)
                {                    
                    //make a new employee 
                    Main.maininstance.panel1.Controls.Add(new Newemployee());
                    //give him admin rights
                    Main.maininstance.sqlReader("SELECT ID FROM Employee ORDER BY ID DESC LIMIT 1");
                    int id = int.Parse(Main.reader["ID"].ToString());
                    Main.maininstance.sqlCommand("INSERT INTO Manager Values('" + id + "')");
                }
                //Or exit the program
                else
                {
                    myConnection.Close();
                    Environment.Exit(0);
                }
            }
            myConnection.Close();
            
             
            //create admin, notify that they'll have to fill in their info in EditEmployees

        }
        }
    }