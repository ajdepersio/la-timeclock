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
    public partial class Schedule : UserControl
    {
        MySqlDataAdapter mySqlDataAdapter;
        MySqlCommandBuilder mySqlCommandBuilder;
        DataTable dataTable;
        DateTime mon, sun;
        public Schedule()
        {
            InitializeComponent();
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            scheduleDatagrid.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            scheduleDatagrid.KeyPress +=new KeyPressEventHandler(Main.maininstance.notIdle_event);

            mon = getmon(DateTime.Parse(weekCalander.Value.ToShortDateString()));
            sun = mon.AddDays(6);
            whoDropdownlist.SelectedItem = "Self";
            weekCalander.Value = mon.Date;

            if (Main.myConnection.State == ConnectionState.Open)
            {
                Main.reader.Close();
                Main.myConnection.Close();
            }
            filldt();
        }

        public void filldt()
        {
            string query = "";
            if (whoDropdownlist.Text == "Self")
            {
                query = "SELECT Date, LName AS Last, FName AS First, Start, End, JID AS Job FROM Schedule JOIN Employee ON Schedule.ID=Employee.ID Where Schedule.ID='" + Main.id + "' AND Date>='" + mon.ToString("yyyy-MM-dd") + "' AND Date<='" + sun.ToString("yyyy-MM-dd") + "' ORDER BY Date, Start";
            }
            else
            {
                query = "SELECT Date, LName AS Last, FName AS First, Start, End, JID AS Job FROM Schedule JOIN Employee ON Schedule.ID=Employee.ID Where Date>='" + mon.ToString("yyyy-MM-dd") + "' AND Date<='" + sun.ToString("yyyy-MM-dd") + "' ORDER BY Date, Start";
            }

            try
            {
                Main.myConnection.Open();
                mySqlDataAdapter = new MySqlDataAdapter(query, Main.myConnection);
                mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

                dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                BindingSource bind = new BindingSource();
                bind.DataSource = dataTable;
                scheduleDatagrid.DataSource = bind;

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



        public DataRowCollection Rows
        {
            get { return dataTable.Rows; }
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            if (weekCalander.Value.DayOfWeek != DayOfWeek.Monday)
            {
                weekCalander.Value = getmon(weekCalander.Value.Date);
            }
            mon = weekCalander.Value;
            sun = mon.AddDays(6);
            filldt();
        }

        public DateTime getmon(DateTime a)
        {
            while (a.DayOfWeek != DayOfWeek.Monday)
            {
                a = a.AddDays(-1);
            }
            return a;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filldt();
        }

    }
}
