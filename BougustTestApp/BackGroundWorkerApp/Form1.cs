using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace BackGroundWorkerApp
{
    public partial class MainForm : Form
    {
        public BackgroundWorker BgwTest { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BgwTest = new BackgroundWorker();
            BgwTest.DoWork += BgwTest_DoWork;
            BgwTest.RunWorkerCompleted += BgwTest_RunWorkerCompleted;
            BgwTest.ProgressChanged += BgwTest_ProgressChanged;
            BgwTest.WorkerReportsProgress = true; //나타낸 값을 가져올때 진행률을 나타낸다.
            BgwTest.WorkerSupportsCancellation = true; //중간에 취소할수있는지

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (BgwTest.IsBusy != true)
            {
                BgwTest.RunWorkerAsync();//BackgroundWorker 비동기 실행
                LblResult.Text = "실행!";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BgwTest.WorkerSupportsCancellation)
            {
                BgwTest.CancelAsync(); // BackgroundWorker 실행취소
                LblResult.Text = "실행취소";
            }
        }

        private void BgwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker; //형변환
            for (int i = 0; i <= 100; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else 
                {
                    Thread.Sleep(20);
                    worker.ReportProgress(i);
                }
            }
        }

        private void BgwTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //LblResult.Text = $"{e.ProgressPercentage}%";
            PgbTest.Value = e.ProgressPercentage;
        }

        private void BgwTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                LblResult.Text = "실행취소";
            }
            else if (e.Error != null)
            {
                LblResult.Text = $"에러 : {e.Error.Message}";
            }
            else { LblResult.Text = "실행완료"; }
        }
    }
}
