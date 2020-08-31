using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
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
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Security.Cryptography;
using System.Globalization;

namespace Accident01.sub
{
    public partial class SubForm : MetroForm
    {
        public string sido, gugun;
        

        public SubForm()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 50;

        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            metroTextBox1.Focus();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainForm search = new MainForm();
            search.Location = this.Location;
            search.ShowDialog();
            this.Close();
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            XmlDocument doc = new XmlDocument();
            Application application = new Application();
            Workbook workbook = application.Workbooks.Open(Filename: @"D:\PKNU2020\StudyC\Accident01\getfile.xls");

            string[] a = new string[2];
            Class1 c = new Class1();
            a = metroTextBox1.Text.Split(' ');
            Worksheet worksheet1 = workbook.Worksheets.Item[a[0]];
            Range range1 = worksheet1.Range["A1:B35"];
            object[,] rawData1 = range1.Value;
            int row = 0, column = 0;
          


            for (int i = 1; i <= rawData1.GetLength(0); i++)
            {
                if (string.IsNullOrEmpty((string)rawData1[i, 1]))
                {
                    MessageBox.Show("원하는 도시 없음", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    metroTextBox1.Text = "";
                    metroTextBox1.Focus();
                    return;
                }

                if(a[1] == (string)rawData1[i,1])
                {
                    row = i;
                    column = 2;
                    break;
                }
                
            }
            //부산시 남구
            StringBuilder str = new StringBuilder();
            str.Append("http://apis.data.go.kr/B552061/frequentzoneLg/getRestFrequentzoneLg");
            str.Append("?serviceKey=uGbPjpUXXzLZAMwlpLN7leSeaQ7cDszrIvGQtKZTfZF4eCkZ5DkoQizRy47w4QCevgeuLdkR8sYvzTsILzCZ%2Fw%3D%3D");
            string k = c.dic[a[0]];

            str.Append($"&secnNm={metroTextBox1.Text}");//검색어
            str.Append("&searchYearCd=2017"); //검색년도
            str.Append($"&siDo={k}");
            str.Append($"&guGun={rawData1[row,column]}");
            str.Append("&pageNo=1"); //페이지 번호
            str.Append("&numOfRows=10");//읽어올 데이터수
            str.Append("&type=xml");

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            dataGridView1.Rows.Clear();

            try
            {
                if (items[0]["sido_sgg_nm"]==null)
                {
                    
                    MessageBox.Show("사고사건 없음", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    metroTextBox1.Text = "";
                    metroTextBox1.Focus();

                    return;
                }

                foreach (XmlNode item in items)
                {

                    dataGridView1.Rows.Add(item["sido_sgg_nm"] != null ?item["sido_sgg_nm"].InnerText:null,  //시도시군구명                
                                            item["occrrnc_cnt"] != null ? item["occrrnc_cnt"].InnerText : null, //발생건수
                                            item["caslt_cnt"] != null ? item["caslt_cnt"].InnerText : null,//사상자수
                                            item["dth_dnv_cnt"] != null ? item["dth_dnv_cnt"].InnerText : null,// 사망자수
                                            item["se_dnv_cnt"] != null ? item["se_dnv_cnt"].InnerText : null, //중상자수
                                            item["sl_dnv_cnt"] != null ? item["sl_dnv_cnt"].InnerText : null //경상자수
                                            );

                }

            }
            catch (NullReferenceException ex)
            {

                MessageBox.Show($"에러발생 : {ex.Message}"
                                 , "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) metroButton1_Click(sender, new EventArgs());
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DOSI.Items.Clear();
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            XmlDocument doc = new XmlDocument();
            Application application = new Application();
            Workbook workbook = application.Workbooks.Open(Filename: @"D:\PKNU2020\StudyC\Accident01\getfile.xls");
            sido = SIDO.SelectedItem.ToString();
            Class1 c = new Class1();
            Worksheet worksheet1 = workbook.Worksheets.Item[SIDO.SelectedItem];
            Range range1 = worksheet1.Range["A1:B35"];
            object[,] rawData1 = range1.Value;

            for (int i = 1; i <= rawData1.GetLength(0); i++)
            {
                if (string.IsNullOrEmpty((string)rawData1[i, 1]))
                {
                    break;
                }

                DOSI.Items.Add((string)rawData1[i, 1]);
                
            }


        }

        private void DOSI_SelectedIndexChanged(object sender, EventArgs e)
        {
            gugun = DOSI.SelectedItem.ToString();
        }

        private void CBO_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            Class1 c = new Class1();
            XmlDocument doc = new XmlDocument();
            Application application = new Application();

            StringBuilder str = new StringBuilder();
            str.Append("http://apis.data.go.kr/B552061/frequentzoneLg/getRestFrequentzoneLg");
            str.Append("?serviceKey=uGbPjpUXXzLZAMwlpLN7leSeaQ7cDszrIvGQtKZTfZF4eCkZ5DkoQizRy47w4QCevgeuLdkR8sYvzTsILzCZ%2Fw%3D%3D");
            
            str.Append($"&secnNm={metroTextBox1.Text}");//검색어
            str.Append("&searchYearCd=2017"); //검색년도
            str.Append($"&siDo={SIDO.SelectedItem.ToString()}");
            str.Append($"&guGun={DOSI.SelectedItem.ToString()}");
            str.Append("&pageNo=1"); //페이지 번호
            str.Append("&numOfRows=10");//읽어올 데이터수
            str.Append("&type=xml");

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            dataGridView1.Rows.Clear();

            try
            {
                if (items[0]["sido_sgg_nm"] == null)
                {

                    MessageBox.Show("사고사건 없음", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    metroTextBox1.Text = "";
                    metroTextBox1.Focus();

                    return;
                }

                foreach (XmlNode item in items)
                {

                    dataGridView1.Rows.Add(item["sido_sgg_nm"] != null ? item["sido_sgg_nm"].InnerText : null,  //시도시군구명                
                                            item["occrrnc_cnt"] != null ? item["occrrnc_cnt"].InnerText : null, //발생건수
                                            item["caslt_cnt"] != null ? item["caslt_cnt"].InnerText : null,//사상자수
                                            item["dth_dnv_cnt"] != null ? item["dth_dnv_cnt"].InnerText : null,// 사망자수
                                            item["se_dnv_cnt"] != null ? item["se_dnv_cnt"].InnerText : null, //중상자수
                                            item["sl_dnv_cnt"] != null ? item["sl_dnv_cnt"].InnerText : null //경상자수
                                            );

                }

            }
            catch (NullReferenceException ex)
            {

                MessageBox.Show($"에러발생 : {ex.Message}"
                                 , "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
    
}
