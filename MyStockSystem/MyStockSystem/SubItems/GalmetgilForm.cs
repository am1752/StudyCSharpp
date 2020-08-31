using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyStockSystem.SubItems
{
    public partial class GalmetgilForm : MetroForm//Form
    {
        public GalmetgilForm()
        {
            InitializeComponent();
        }

        private void GalmetgilForm_Load(object sender, EventArgs e)
        {
            //폰트 나눔고딕체로 변경
            DgvSearchItems.Font = new Font(@"NanumGothic", 9, FontStyle.Regular);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Mtlback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainForm main = new MainForm();
            main.Location = this.Location;
            main.ShowDialog();
            this.Close();
        }

        private void DgvSearchItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
         
            StringBuilder str = new StringBuilder();
            str.Append("http://apis.data.go.kr/6260000/BusanGalmaetGilService/getGalmaetGilInfo");
            str.Append("?ServiceKey=uGbPjpUXXzLZAMwlpLN7leSeaQ7cDszrIvGQtKZTfZF4eCkZ5DkoQizRy47w4QCevgeuLdkR8sYvzTsILzCZ%2Fw%3D%3D");
            str.Append("&pageNo=1");
            str.Append("&numOfRows=10");
            str.Append("&resultType=json");

            string json = wc.DownloadString(str.ToString());
            JObject obj = JObject.Parse(json);

            JArray items = JArray.Parse(obj.SelectToken("getGalmaetGilInfo.item").ToString());
            

            DgvSearchItems.Rows.Clear();
            
         
            try
            {
                

                foreach (var item in items)
                {
                    DgvSearchItems.Rows.Add(
                           $"{item.SelectToken("kosNm")}",
                           $"{item.SelectToken("kosType")}",
                           $"{item.SelectToken("kosTxt")}",
                           $"{item.SelectToken("img")}",
                           $"{item.SelectToken("txt1")}",
                           $"{item.SelectToken("title")}",
                           $"{item.SelectToken("txt2")}"

                    );

                }

                 

            }
            catch (NullReferenceException ex)
            {

                MessageBox.Show($"에러발생 : {ex.Message}"
                                 ,"에러",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            

            DgvSearchItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void TextSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) BtnSearch_Click(sender,new EventArgs());
        }

        private void DgvSearchItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selvalue = DgvSearchItems.Rows[e.RowIndex].Cells[3].Value.ToString();
            //MessageBox.Show(selvalue);
            DownloadForm form = new DownloadForm();
            form.ParentUrl = selvalue;
            form.ShowDialog();
        }
    }
}
