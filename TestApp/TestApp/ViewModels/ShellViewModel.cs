using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
//using System.Web.UI.DataVisualization.Charting;
//using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;

namespace TestApp.ViewModels
{
    public class ShellViewModel
    {
        [System.ComponentModel.Bindable(true)]
        public string InputGestureText { get; set; }

        public class BindableAttribute : Attribute
        {
            public int MyProperty
            {
                get
                {
                    // Insert code here.
                    return 0;
                }
                set
                {
                    // Insert code here.
                }
            }

            //public bool IsSimulation { get; private set; }

        

        }
    }
}
