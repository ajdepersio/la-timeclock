﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Los_Alamos_Timeclock.Manager.Admin
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

    public partial class Paychecks : UserControl
    {

        public Paychecks()
        {
            InitializeComponent();

            //sets the background image to the user's image, or the default
            try
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.backgroundImage);
            }
            catch (Exception)
            {
                this.BackgroundImage = Properties.Resources._1287421014661;
            }

            //events that reset the idle time
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            payTextbox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            payTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event); 

            //sets the start calander's date to monday, and the end to sunday
            if (DateTime.Today.DayOfWeek != DayOfWeek.Monday)
            {
                startCalander.Value = getDay(startCalander.Value, DayOfWeek.Monday);
            }
            endCalander.Value = startCalander.Value.AddDays(6);

            //labels the timespan for the pay period
            weekLabel.Text = "Pay for " + startCalander.Value.ToShortDateString() + " - " + endCalander.Value.ToShortDateString();
            //calculate pay
            calculatePay();

        }

        //update the timespan label and pay whenever either of the dates are changed
        private void startCalander_ValueChanged(object sender, EventArgs e)
        {
            endCalander.MinDate = startCalander.Value;

            weekLabel.Text = "Pay for " + startCalander.Value.ToShortDateString() + " - " + endCalander.Value.ToShortDateString();
            calculatePay();
        }
        private void endCalander_ValueChanged(object sender, EventArgs e)
        {
            if (endCalander.Value < startCalander.Value)
            {
                endCalander.Value = startCalander.Value;
            }
            calculatePay();
        }

        //gets the most recent occurance of a specified 'day', 'day' compared to datetime a
        public static DateTime getDay(DateTime a, DayOfWeek day)
        {
            while (a.DayOfWeek != day)
            {
                a = a.AddDays(-1);
            }
            return a;
        }

        //method to calculate pay
        private void calculatePay()
        {
            //variables to be used
            string id = "";
            TimeSpan hours = TimeSpan.FromHours(0);
            Double weekHours = 0;
            Double totalHours = 0;
            Double hourlyRate = 0.00;
            Double pay = 0.00;
            Double totalPay = 0.00;
            Double totalTips = 0.00;
            DateTime weekDate = startCalander.Value;

            try
            {
                Main.myConnection.Open();

                //select all shifts between the two selected dates
                String c = "SELECT d.LName, d.FName, d.MName, a.*,b.JSPay, c.JPay " +
                "FROM `Hours Worked` a " +
                "LEFT OUTER JOIN `Jobs` b " +
                "ON a.JID=b.JID " +
                "LEFT OUTER JOIN `Employee Jobs` c " +
                "ON b.JID=c.JID AND a.ID = c.ID " +
                "JOIN `Employee` d " +
                "ON a.ID=d.ID " +
                "WHERE a.Date>='" + startCalander.Value.ToString("yyyy-MM-dd") +
                "' AND a.Date<='" + endCalander.Value.ToString("yyyy-MM-dd") +
                "' AND a.Status='OUT'" +
                "ORDER BY d.LName, d.FName " +
                "LIMIT 0,1000";

                //output is what will be printed, it starts empty and concatanates the information
                string output = "";
                MySqlCommand command = new MySqlCommand(c, Main.myConnection);
                Main.reader = command.ExecuteReader();

                //while it reads
                while (Main.reader.Read())
                {
                    //checks to see if the id is different than the current id
                    if (Main.reader["ID"].ToString() != id)
                    {
                        //if id isn't empty, then there was an employee before this one, and it needs to output that employee's totals
                        if (id != "")
                        {
                            output = output + "\tTotal Hours: \t" + totalHours + "\n" +
                                              "\tGross Pay: \t$" + String.Format("{0:0.00}", Math.Round(totalPay, 2)) + "\n";
                            //if the employee has tips, output an extra line, otherwise just total it
                            if (totalTips > 0)
                            {
                                output = output + "\tTotal Tips: \t$" + String.Format("{0:0.00}", Math.Round(totalTips, 2)) + "\n\tTotal Pay: \t$" + String.Format("{0:0.00}", Math.Round(totalPay + totalTips, 2)) + "\n\n";
                            }
                            else
                            {
                                output = output + "\tTotal Pay: \t$" + String.Format("{0:0.00}", Math.Round(totalPay, 2)) + "\n\n";
                            }
                        }
                        //updates the id and resets all the values
                        id = Main.reader["ID"].ToString();
                        output = output + Main.reader["LName"].ToString() + ", " + Main.reader["FName"].ToString() + " " + Main.reader["MName"].ToString() + "\n";
                        weekDate = startCalander.Value;
                        totalHours = 0;
                        weekHours = 0;
                        totalPay = 0.00;
                        totalTips = 0.00;
                    }


                    if (Main.reader["Start"].ToString() != "" && Main.reader["End"].ToString() != "")
                    {
                        //checks if the date on the selected record is in the same week, if not it resets the weekHours and sets the new weekDate
                        if (DateTime.Parse(Main.reader["Date"].ToString()) > (weekDate.AddDays(6)))
                        {
                            weekHours = 0;
                            weekDate = getDay(DateTime.Parse(Main.reader["Date"].ToString()), weekDate.DayOfWeek);
                        }

                        //if the end time is before the begin time, add a day so it will calculate correctly
                        if (Main.roundtime(DateTime.Parse(Main.reader["End"].ToString())) < Main.roundtime(DateTime.Parse(Main.reader["Start"].ToString())))
                        {
                            hours = Main.roundtime(DateTime.Parse(Main.reader["End"].ToString())).AddHours(24).Subtract(Main.roundtime(DateTime.Parse(Main.reader["Start"].ToString())));
                        }
                        else
                        {
                            hours = Main.roundtime(DateTime.Parse(Main.reader["End"].ToString())).Subtract(Main.roundtime(DateTime.Parse(Main.reader["Start"].ToString())));
                        }


                        if (Main.reader["Lout"].ToString() != "" && Main.reader["Lin"].ToString() != "")
                        {
                            DateTime lunchOut = DateTime.Parse(Main.reader["Lout"].ToString());
                            DateTime lunchIn = DateTime.Parse(Main.reader["Lin"].ToString());

                            //if the person got back from their lunch after midnight and left before, add a day to the in time
                            if (Main.roundtime(DateTime.Parse(Main.reader["Lin"].ToString())) < Main.roundtime(DateTime.Parse(Main.reader["Lout"].ToString())))
                            {
                                hours = hours.Subtract(roundTime((DateTime.Parse(Main.reader["Lin"].ToString()).AddHours(24)).Subtract(DateTime.Parse(Main.reader["Lout"].ToString()))));
                            }
                            else
                            {
                                hours = hours.Subtract(roundTime(DateTime.Parse(Main.reader["Lin"].ToString()).Subtract(DateTime.Parse(Main.reader["Lout"].ToString()))));
                            }
                        }

                        //if the employee has no custom pay, use the job's starting pay
                        if (Main.reader["JPay"].ToString() == "")
                        {
                            hourlyRate = Double.Parse(Main.reader["JSPay"].ToString());
                        }
                        else
                        {
                            hourlyRate = Double.Parse(Main.reader["JPay"].ToString());
                        }

                        //statements to calculate the shift's pay ammount, calculates overtime if the employee worked more than 40 hours in a week
                        if (weekHours >= 40)
                        {
                            hourlyRate = hourlyRate * 1.5;
                            pay = hourlyRate * (hours.Hours + (hours.Minutes / 15 * .25));
                        }
                        else if ((weekHours + (hours.Hours + (hours.Minutes / 15) * .25)) > 40)
                        {
                            TimeSpan a = TimeSpan.FromHours(40);
                            a = a.Subtract(TimeSpan.FromHours(totalHours));
                            hours = hours.Subtract(a);
                            pay = (hourlyRate * (a.Hours + (a.Minutes / 15 * .25))) + ((hourlyRate * 1.5) * (hours.Hours + (hours.Minutes / 15 * .25)));
                            hours = hours.Add(a);
                        }
                        else
                        {
                            pay = hourlyRate * (hours.Hours + (hours.Minutes / 15 * .25));
                        }

                        //adds the employee's tips if they're not empty
                        if (Main.reader["Tips"].ToString() != "")
                        {
                            totalTips += Double.Parse(Main.reader["Tips"].ToString());
                        }

                        //adds to the employee's total pay and resets the values for the next run through
                        totalPay += pay;
                        pay = 0.00;
                        totalHours += hours.Hours + (hours.Minutes / 15) * .25;
                        weekHours += hours.Hours + (hours.Minutes / 15) * .25;
                        hours = TimeSpan.FromHours(0);
                    }
                }
                //outputs the final employee's information
                if (id != "")
                {
                    output = output + "\tTotal Hours: \t" + totalHours + "\n" +
                                      "\tGross Pay: \t$" + String.Format("{0:0.00}", Math.Round(totalPay, 2)) + "\n";
                    if (totalTips > 0)
                    {
                        output = output + "\tTotal Tips: \t$" + String.Format("{0:0.00}", Math.Round(totalTips, 2)) + "\n\tTotal Pay: \t$" + String.Format("{0:0.00}", Math.Round(totalPay + totalTips, 2)) + "\n\n";
                    }
                    else
                    {
                        output = output + "\tTotal Pay: \t$" + String.Format("{0:0.00}", Math.Round(totalPay, 2)) + "\n\n";
                    }
                }
                id = "";
                payTextbox.Text = output;

            }
            finally
            {
                Main.myConnection.Close();
            }
        }

        //rounds timespans to 15 minute intervals
        public TimeSpan roundTime(TimeSpan a)
        {
            int q = 0;
            while (a.Minutes > 15)
            {
                a = a.Subtract(TimeSpan.FromMinutes(15));
                q++;
            }
            if (a.Minutes >= 8)
            {
                a = a.Subtract(TimeSpan.FromMinutes(a.Minutes));
                a = a.Add(TimeSpan.FromMinutes((q * 15) + 15));
            }
            else
            {
                a = a.Subtract(TimeSpan.FromMinutes(a.Minutes));
                a = a.Add(TimeSpan.FromMinutes(q * 15));
            }
            a = a.Subtract(TimeSpan.FromSeconds(a.Seconds));

            return a;
        }
    }
}
