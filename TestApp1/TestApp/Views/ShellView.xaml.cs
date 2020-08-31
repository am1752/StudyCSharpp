using Caliburn.Micro;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO.Ports;
//using System.Web.UI.DataVisualization.Charting;
//using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;
using TestApp.ViewModels;

namespace TestApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        IWindowManager manager = new WindowManager();
        //private readonly IWindowManager windowManager;
        private short xCount = 200;
        private short maxPhotoVal = 1023;
       


        public ShellView()
        {
            
            InitializeComponent();
            // InitChart();

        }

        public void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the interop host control.
                WindowsFormsHost host = new WindowsFormsHost();
               
           
            // Create the MaskedTextBox control.
            MaskedTextBox mtbDate = new MaskedTextBox("00/00/0000");

            // Assign the MaskedTextBox control as the host control's child.
           
        }

       













    } 
}
