using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStockSystem.SubItems
{
    public partial class DownloadForm : MetroForm
    {
        public string ParentUrl { get; set; }
        WebClient client;

        public DownloadForm()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 50;
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            label.Text = ParentUrl;
            client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string fileName = ParentUrl.Substring(ParentUrl.IndexOf('=') + 1);
            pictureBox1.Load(Environment.CurrentDirectory + $@"\{fileName}");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        } 

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar1.Value = e.ProgressPercentage;

                if(e.BytesReceived == e.TotalBytesToReceive)
                {
                    Client_DownloadFileCompleted(sender,null);
                }
            }                
                ));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(StartDownload));
            thread.Start();
        }

        private void StartDownload()
        {
            Uri uri = new Uri(ParentUrl);
            string fileName = ParentUrl.Substring(ParentUrl.IndexOf('=') + 1);
            client.DownloadFileAsync(uri,Environment.CurrentDirectory + $@"\{fileName}");

        }

        
    }
}
