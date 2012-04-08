﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Los_Alamos_Timeclock
{
        /*
     This file is part of Los Alamos Timeclock.

    Los Alamos Timeclock is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Los Alamos Timeclock is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Los Alamos Timeclock.  If not, see <http://www.gnu.org/licenses/>.
     */

    public partial class Request : UserControl
    {
        MySqlDataAdapter mySqlDataAdapter;
        MySqlCommandBuilder mySqlCommandBuilder;
        DataTable dataTable;
        Boolean existingEntry = false;
        Boolean updating = false;
        String existingSDate;
        public Request()
        {
            InitializeComponent();
            startCalander.MinDate = DateTime.Today;
            endCalander.MinDate = DateTime.Today;
            filldt();
            updateFields();
        }

        /** Method to fill the datagridview
         * 
         * @author Nate Rush
         */

        public void filldt()
        {
            //query for the database
            String query = "Select SDate as 'Start Date', EDate as 'End Date', Reason, `Submitted Date` FROM Requests WHERE ID='"+Main.id+"' and EDate>='"+DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")+"'";
            try
            {
                Main.myConnection.Open();
                mySqlDataAdapter = new MySqlDataAdapter(query, Main.myConnection);
                mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

                dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                requestsDatagrid.DataSource = bind;

                Main.myConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Main.myConnection.Close();
            }
        }

        /** Method to update the fields
         * 
         * @author Nate Rush
         */

        void updateFields()
        {
            //checks to see if the program is already updating, prevents infinite loop when it sets the start date
            if (!updating)
            {
                try
                {
                    //sets updating to true so only updateFields won't run recursively
                    updating = true;
                    Main.myConnection.Open();
                    //checks if the date is already requested by the employee
                    Main.maininstance.sqlReader("SELECT * FROM Requests WHERE ID='" + Main.id +
                                                "' AND SDate<='" + startCalander.Value.ToString("yyyy-MM-dd") +
                                                "' AND EDate>='" + startCalander.Value.ToString("yyyy-MM-dd") + "'");

                    //true if the date is requested
                    if (Main.reader.HasRows)
                    {
                        existingSDate = DateTime.Parse(Main.reader["SDate"].ToString()).ToString("yyyy-MM-dd");

                        //if the employee is already editing the entry it won't change the fields
                        if (!existingEntry)
                        {
                            //sets field values to the request's values
                            requestButton.Text = "Update Request";
                            startCalander.Value = DateTime.Parse(Main.reader["SDate"].ToString()).Date;
                            endCalander.MinDate = startCalander.Value;
                            //prevents requesting negative days off
                            endCalander.Value = DateTime.Parse(Main.reader["EDate"].ToString()).Date;
                            reasonTextbox.Text = Main.reader["Reason"].ToString();
                        }

                        //used to tell the request/update button what to do
                        existingEntry = true;
                    }
                    else
                    {
                        //no entry, so everything goes back to default
                        existingEntry = false;
                        existingSDate = "";
                        requestButton.Text = "Request";
                        endCalander.MinDate = startCalander.Value;
                    }
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.ToString());
                }
                finally
                {
                    //closes the connection
                    Main.myConnection.Close();
                    //signals the end of the update so it can be done again
                    updating = false;
                }
            }
        }

        private void startCalander_ValueChanged(object sender, EventArgs e)
        {
            updateFields();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //checks to see if a valid entry is selected
            if (existingEntry)
            {
                //double checks with user if they want to delete the entry
                DialogResult result = MessageBox.Show("Are you sure you wish to delete this request?", "Delete Request?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    String delete = "DELETE FROM Requests WHERE ID='" + Main.id +
                                    "' AND SDate='" + startCalander.Value.ToString("yyyy-MM-dd") +
                                    "' AND EDate='" + endCalander.Value.ToString("yyyy-MM-dd") + "'";
                    Main.maininstance.sqlCommand(delete);
                    filldt();
                    updateFields();
                }
                else
                {
                    //no record is selected so there is nothing to delete
                    MessageBox.Show("No record selected");
                }
            }
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            //updates if there is an entry selected
            if (existingEntry)
            {
                String update = "Update Requests "+
                                "SET SDate='"+startCalander.Value.ToString("yyyy-MM-dd")+"', "+
                                "EDate='"+endCalander.Value.ToString("yyyy-MM-dd")+"', "+
                                "Reason='" + reasonTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'")+"' "+
                                "WHERE ID='"+Main.id+"' AND SDate='"+existingSDate+"'";
                Main.maininstance.sqlCommand(update);
                filldt();
                updateFields();
            }
            //creates a new entry
            else
            {
                String insert="INSERT INTO Requests VALUES('"+Main.id+"','"+
                                    startCalander.Value.ToString("yyyy-MM-dd")+"','"+
                                    endCalander.Value.ToString("yyyy-MM-dd")+"',"+
                                    "NOW(),'"+
                                    reasonTextbox.Text.Replace(@"\", @"\\").Replace("'", @"\'")+
                                        "')";
                Main.maininstance.sqlCommand(insert);
                filldt();
                updateFields();
            }
        }
    }
}