using Caliburn.Micro;
using LiveCharts;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using TestApp.Helper;
using TestApp.Views;

//using ​System.Windows.Threading.Dispatcher;
//using System.Web.UI.DataVisualization.Charting;
//using System.Timers;

namespace TestApp.ViewModels
{
    public class ShellViewModel : Conductor<Object>, IHaveDisplayName
    {
        
     

        [System.ComponentModel.Bindable(true)]
        public string InputGestureText { get; set; }

        string txtSensorCount;
        string lblPhotoRegistor;
        string lblConnectionTime;
        int pgbPhotoRegistor;
        string btnPortValue;
        string p;

        string strConnString = "Server=localhost;Port=3306;" +
            "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";

        IWindowManager manager = new WindowManager();
        SerialPort serial;
        private short xCount = 200;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();
        List<string> cboSerialPort = new List<string>();
        List<string> txt = new List<string>();

        public bool IsSimulation { get; set; }
   

        Timer timer = new Timer();
        Random rand = new Random();
        WindowsFormsHost host = new WindowsFormsHost();
        MaskedTextBox mtbDate = new MaskedTextBox("00/00/0000");
        ChartValues<float> myWinformChart = new ChartValues<float>();

        public ShellViewModel()
        {
           
            InitControls();
               

        }
        
        






        public ChartValues<float> MyWinformChart
        {
            get => myWinformChart;
            set
            {
                myWinformChart = value;
                NotifyOfPropertyChange(() => MyWinformChart);
                NotifyOfPropertyChange(() => DisplayName);
            }
        }
          

        public string BtnPortValue
        {
            get => btnPortValue;
            set
            {
                btnPortValue = value;
                NotifyOfPropertyChange(() => BtnPortValue);
            }
        }

        public List<string> CboSerialPort
        {
            get => cboSerialPort;
            set
            {
                cboSerialPort = value;
                NotifyOfPropertyChange(() => CboSerialPort);
                NotifyOfPropertyChange(() => DisplayName);
            }
        }

        public List<SensorData> PhotoDatas
        {
            get => photoDatas;
            set
            {
                photoDatas = value;
                NotifyOfPropertyChange(() => PhotoDatas);
            }
        }

        public List<string> Txt
        {
            get => txt;
            set
            {
                txt = value;
                NotifyOfPropertyChange(() => Txt);
            }
        }


        public int PgbPhotoRegistor{
            get=> pgbPhotoRegistor;
            set
            {
                pgbPhotoRegistor = value;

                NotifyOfPropertyChange(() => PgbPhotoRegistor);
            }
        }

        public string TxtSensorCount
        {
            get => txtSensorCount;
            set
            {
                txtSensorCount = value;

                NotifyOfPropertyChange(() => TxtSensorCount);

            }
        }

        public string LblPhotoRegistor
        {
            get => lblPhotoRegistor;
            set
            {
                lblPhotoRegistor = value;
                NotifyOfPropertyChange(() => LblPhotoRegistor);
                NotifyOfPropertyChange(() => CanBtnConnect);
            }
        }

        

        public string LblConnectionTime
        {
            get => lblConnectionTime;
            set
            {
                lblConnectionTime = value;
                NotifyOfPropertyChange(() => LblConnectionTime);
            }
        }

        int val;
        public int Val
        {
            get => val;
            set
            {
                val = value;
                NotifyOfPropertyChange(() => Val);
            }
        }

        public string portName;
        public string PortName
        {
            get => portName;
            set
            {
                portName = value;
                NotifyOfPropertyChange();
            }
        }


        public void BtnConnect()
        {
            serial = new SerialPort(PortName);
            serial.DataReceived += Serial_DataReceived;
            serial.Open();
            LblConnectionTime = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
            CanBtnConnect = false;
            CanBtnDisConnect = true;

        }


        bool canBtnConnect;
        public bool CanBtnConnect
        {
            get => canBtnConnect;
            set
            {
                canBtnConnect = value;
                NotifyOfPropertyChange(() => CanBtnConnect);
            }
        }

        public void BtnDisConnect()
        {
            
            serial.Close();
            CanBtnConnect= true;
            CanBtnDisConnect = false;

        }

        bool canBtnDisConnect;
        public bool CanBtnDisConnect
        {
            get => canBtnDisConnect;
            set
            {
                canBtnDisConnect = value;
                NotifyOfPropertyChange(() => CanBtnDisConnect);
            }
        }

        public string P
        {
            get => p;
            set
            {
                p = value;
                NotifyOfPropertyChange(() => P);
            }
        }



        public void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            DisplayValue(sVal);
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


        


        public void MenuClose()
        {
            Environment.Exit(0);
        }

        public void Information()
        {

            dynamic settings = new ExpandoObject();
            //새창 크기조절
            settings.Height = 300;
            settings.Width = 580;
            settings.SizeToContent = SizeToContent.Manual;
            InfoViewModel dialogVM = new InfoViewModel();
            manager.ShowWindow(dialogVM, null, settings);

        }

        public void InitControls()
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Add(item);
            }
            CboSerialPort.Insert(0,"Select Port");

            
            CanBtnConnect = true;
            CanBtnDisConnect = false;
        }

        List<string> chart1 = new List<string>();

        public List<string> Chart1 {
            get => chart1;
            set
            {
                chart1 = value;
                NotifyOfPropertyChange(() => Chart1);
            }
        }

        private void DisplayValue(string sVal)
        {
            
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);
                InsertDataToDB(data);

                TxtSensorCount = photoDatas.Count.ToString();
                PgbPhotoRegistor = v;
                LblPhotoRegistor = v.ToString();

                string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}";

                Txt.Add($"{item}\n");
                P += Txt[photoDatas.Count-1];

                MyWinformChart.Add(v);
                Val = (int)MyWinformChart[photoDatas.Count-1];

               

                if (IsSimulation == false)
                    BtnPortValue = $"{serial.PortName}\n{sVal}";
                else
                    BtnPortValue = $"{sVal}";
            }
            catch (Exception ex)
            {
                Txt.Add($"Error : {ex.Message}\n");
                //Txt.ScrollToEnd();
            }
        }

        public void MenuDisConnect(object obj)
        {
            timer.Stop();
            IsSimulation = false;       

        }

        public void MenuConnect(object obj)
        {
            IsSimulation = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }

        public void Close()
        {
            Environment.Exit(0);
        }

        public void Clear()
        {

            PhotoDatas.Clear();
            MyWinformChart.Clear();
        }

        ICommand sim_Start_Command;
        public ICommand Sim_Start_Command => sim_Start_Command ?? (sim_Start_Command = new RelayCommand<object>(MenuConnect));

        ICommand sim_Stop_Command;
        public ICommand Sim_Stop_Command => sim_Stop_Command ?? (sim_Stop_Command = new RelayCommand<object>(MenuDisConnect));
    }

}