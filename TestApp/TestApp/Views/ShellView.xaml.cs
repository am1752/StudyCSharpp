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
using System.Windows.Input;

namespace TestApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        IWindowManager manager = new WindowManager();
        //private readonly IWindowManager windowManager;
        SerialPort serial;
        private short xCount = 200;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();

        string strConnString = "Server=localhost;Port=3306;" +
            "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";
        public bool IsSimulation { get; set; }

        Timer timer = new Timer();
        Random rand = new Random();

        public ShellView()
        {
            InitializeComponent();
            InitControls();
            InitChart();

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the interop host control.
                WindowsFormsHost host =
                new WindowsFormsHost();
                
           

            // Create the MaskedTextBox control.
            MaskedTextBox mtbDate = new MaskedTextBox("00/00/0000");

            // Assign the MaskedTextBox control as the host control's child.
           
        }


        private void InitChart()
        {
            Chart chart = this.FindName("MyWinformChart") as Chart;

            chart.ChartAreas.Clear();
            chart.ChartAreas.Add("sensor");
            chart.ChartAreas["sensor"].AxisX.Minimum = 0;
            chart.ChartAreas["sensor"].AxisX.Maximum = xCount;
            chart.ChartAreas["sensor"].AxisX.Interval = xCount / 4;
            chart.ChartAreas["sensor"].AxisX.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["sensor"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas["sensor"].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas["sensor"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas["sensor"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;
            chart.ChartAreas["sensor"].AxisY.Minimum = 0;
            chart.ChartAreas["sensor"].AxisY.Maximum = maxPhotoVal + 1;
            chart.ChartAreas["sensor"].AxisY.Interval = xCount;
            chart.ChartAreas["sensor"].AxisY.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["sensor"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart.ChartAreas["sensor"].BackColor = Color.DarkBlue;
            chart.ChartAreas["sensor"].CursorX.AutoScroll = true;

            chart.Series.Clear();
            chart.Series.Add("photoregistor");
            chart.Series["photoregistor"].ChartType = SeriesChartType.Line;
            chart.Series["photoregistor"].Color = Color.LightGreen;
            chart.Series["photoregistor"].BorderWidth = 3;

            if (chart.Legends.Count > 0)
                chart.Legends.RemoveAt(0);


        }


        private void InitControls()
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(item);
            }
            CboSerialPort.Text = "Select Port";

            PgbPhotoRegistor.Minimum = 0;
            PgbPhotoRegistor.Maximum = maxPhotoVal;

            BtnConnect.IsEnabled = BtnDisconnect.IsEnabled = false;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            this.BeginInvoke(new System.Action(delegate { DisplayValue(sVal); }));
        }




        private void DisplayValue(string sVal)
        {
            Chart chart = this.FindName("MyWinformChart") as Chart;
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);
                InsertDataToDB(data);

                TxtSensorCount.Text = photoDatas.Count.ToString();
                PgbPhotoRegistor.Value = v;
                LblPhotoRegistor.Text = v.ToString();

                string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}";

                Txt.AppendText($"{item}\n");
                Txt.ScrollToEnd();

                chart.Series[0].Points.Add(v);

                chart.ChartAreas[0].AxisX.Minimum = 0;
                chart.ChartAreas[0].AxisX.Maximum =
                    (photoDatas.Count >= xCount) ? photoDatas.Count : xCount;

                if (photoDatas.Count > xCount)
                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(
                        photoDatas.Count - xCount, photoDatas.Count);
                else
                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(0, xCount);

                if (IsSimulation == false)
                    BtnPortValue.Content = $"{serial.PortName}\n{sVal}";
                else
                    BtnPortValue.Content = $"{sVal}";
            }
            catch (Exception ex)
            {
                Txt.AppendText($"Error : {ex.Message}\n");
                Txt.ScrollToEnd();
            }
        }

        private void InsertDataToDB(SensorData data)
        {
            string strQuery = "INSERT INTO sensordatatbl " +
                " (Date, Value) " +
                " VALUES " +
                " (@Date, @Value) ";

            using (MySqlConnection conn = new MySqlConnection(strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }

        private void BtnConnect_Click_1(object sender, RoutedEventArgs e)
        {
            serial.Open();
            LblConnectionTime.Text = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
            BtnConnect.IsEnabled = false;
            BtnDisconnect.IsEnabled = true;
        }

        private void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            serial.Close();
            BtnConnect.IsEnabled = true;
            BtnDisconnect.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }



        private void CboSerialPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var portName = CboSerialPort.SelectedItem.ToString();
            serial = new SerialPort(portName);
            serial.DataReceived += Serial_DataReceived;

            BtnConnect.IsEnabled = true;
        }

        private void MenuSubItemStart(object sender, RoutedEventArgs e)
        {
            IsSimulation = true;
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();

            // serial통신 끊기
            BtnDisconnect_Click(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = this.FindName("MyWinformChart") as Chart;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = photoDatas.Count;
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(0, photoDatas.Count);
            chart.ChartAreas[0].AxisX.Interval = photoDatas.Count / 4;
        }

        private void btn_Zoom_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = this.FindName("MyWinformChart") as Chart;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = photoDatas.Count;
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(photoDatas.Count - xCount, photoDatas.Count);
            chart.ChartAreas[0].AxisX.Interval = photoDatas.Count / 4;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            IsSimulation = false;
                                    
            // serial통신 끊기
            BtnDisconnect_Click(sender, e);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            //dynamic settings = new ExpandoObject();
            ////새창 크기조절
            //settings.Height = 300;
            //settings.Width = 580;
            //settings.SizeToContent = SizeToContent.Manual;

            //manager.ShowWindow(new InfoView(), null, settings);

            //InfoView dialogVM = new InfoView();
            //bool? success = windowManager.ShowDialog(dialogVM);
        }

        

        private void MenuItem_CLOSE(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    } 
}
