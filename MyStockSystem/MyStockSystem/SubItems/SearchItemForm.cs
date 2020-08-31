using MetroFramework.Forms;
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
    public partial class SearchItemForm : MetroForm//Form
    {
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
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
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();
            str.Append("http://api.seibro.or.kr/openapi/service/StockSvc/getStkIsinByNmN1");//open API기본URL
            str.Append("?serviceKey=MwEy9o3P8TdMbsa%2FuOYpkDxsjyPYO4a8KFPhEJhVeKLrrtsH4KcT3Hq1xCzktEScPSLGr%2Fck78nkPvIrSjhdkQ%3D%3D"); //인증 키
            str.Append($"&secnNm={TextSearchItem.Text}");//검색어
            str.Append("&pageNo=1"); //페이지 수
            str.Append("&numOfRows=200");//읽어올 데이터수
            str.Append("&martTpcd=11");//주시시장 종류 : 11은 유가증권시장

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            DgvSearchItems.Rows.Clear();

            try
            {
                

                    foreach (XmlNode item in items)
                {
                    DgvSearchItems.Rows.Add(item["isin"].InnerText,//isin 표준코드
                                           //item["issuDt"] == null ? string.Empty : item["issuDt"].InnerText,//주식발행일자
                                            item["issuDt"].InnerText,
                                            item["korSecnNm"].InnerText,//한글종목명
                                            item["secnKacdNm"].InnerText,// 보통주/우선주
                                            item["shotnIsin"].InnerText //단축키
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
    }
}
