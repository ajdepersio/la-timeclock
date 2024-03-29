﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

    /* Class to allow the user to view the file log.txt from within the program */

    public partial class viewLog : UserControl
    {            
        public viewLog()
        {
            InitializeComponent();

            //Load the background image
            try
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.backgroundImage);
            }
            catch (Exception)
            {
                this.BackgroundImage = Properties.Resources._1287421014661;
            }

            //Set idle event handlers
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            logViewBox.MouseMove += new System.Windows.Forms.MouseEventHandler(Main.maininstance.notIdle_event);
            logViewBox.KeyDown += new System.Windows.Forms.KeyEventHandler(Main.maininstance.notIdle_event); 

            //Set logViewBox's text to the return of Log.viewLog()
            logViewBox.Text = Log.viewLog();
        }
    }
}
