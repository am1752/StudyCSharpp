using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace BookRentalShopApp20.Items
{
    public partial class BooksMngForm : MetroForm
    {
        readonly string strTblName = "divTbl";

        BaseMode MyMode = BaseMode.NONE;    // 최초에는 기본상태

        public BooksMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            InitControls();
            UpdateComboDivision();
            UpdateData();
        }

        private void UpdateComboDivision()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Division, Names FROM divTbl ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while(reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0]. ToString());
                }

                CboDivision.DataSource = new BindingSource(temps, null);
                CboDivision.DisplayMember = "Key";
                CboDivision.ValueMember = "Value";
                //CboDivision.SelectedIndex = -1;
            }
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT b.Idx, " +
                                   "       b.Author, " +
                                   "       b.Division, " +
                                   "       d.Names AS DivisionName, " +
                                   "       b.Names, " +
                                   "       b.ReleaseDate, " +
                                   "       b.ISBN, " +
                                   "       b.Price " +
                                   "  FROM bookstbl AS b " +
                                   " INNER JOIN divTbl AS d " +
                                   "    ON b.Division = d.Division ";

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdBooksTbl.DataSource = ds;
                GrdBooksTbl.DataMember = strTblName;
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            DataGridViewColumn column;

            column = GrdBooksTbl.Columns[0];
            column.Width = 150;
            column.HeaderText = "번호";

            column = GrdBooksTbl.Columns[1];
            column.Width = 120;
            column.HeaderText = "저자명";

            column = GrdBooksTbl.Columns[2];
            column.Visible = false;

            column = GrdBooksTbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "장르";

            column = GrdBooksTbl.Columns[4];
            column.Width = 200;
            column.HeaderText = "이름";

            column = GrdBooksTbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "출간일";

            column = GrdBooksTbl.Columns[6];
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdBooksTbl.Columns[7];
            column.Width = 100;
            column.HeaderText = "가격";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            MyMode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }

        private void InitControls()
        {
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtIdx.Focus();

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;

            MyMode = BaseMode.NONE;
            /*
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("선택", "00");
            dic.Add("서울특별시", "11");
            dic.Add("부산광역시", "21");
            dic.Add("대구광역시", "22");
            dic.Add("인천광역시", "23");
            dic.Add("광주광역시", "24");
            dic.Add("대전광역시", "25");
            dic.Add("울산광역시", "26");

            CboDivision.DataSource = new BindingSource(dic, null);
            CboDivision.DisplayMember = "Key";
            CboDivision.ValueMember = "Value";
            */
        }

        // 삭제메소드
        /*
        private void DeleteProcess()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM divtbl " +
                                      " WHERE Division = @Division ";

                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlType.VarChar);
                    paramDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateData();
            }
        }
        */

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtIdx.ReadOnly = false;

            MyMode = BaseMode.INSERT;       // 신규입력모드
        }

        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtIdx.Text)||
                string.IsNullOrEmpty(TxtAuthor.Text)||
                CboDivision.SelectedIndex<1||
                string.IsNullOrEmpty(TxtNames.Text)||
                string.IsNullOrEmpty(TxtISBN.Text))
            {
                MetroMessageBox.Show(this, " 빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(MyMode == BaseMode.NONE)
            {
                MetroMessageBox.Show(this, "신규등록버튼을 누르고 신규등록하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if(MyMode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = " UPDATE bookstbl " +
                                          "    SET Author       = @Author, " +
                                          "        Division     = @Division, " +
                                          "        Names        = @Names, " +
                                          "        ReleaseDate  = @ReleaseDate, " +
                                          "        ISBN         = @ISBN, " +
                                          "        Price        = @Price " +
                                          "  WHERE Idx    = @Idx ";
                    }
                    else if(MyMode == BaseMode.INSERT)
                    {
                        //cmd.CommandText = " "
                    }



                    MySqlParameter paramAuthor = new MySqlParameter("@Author", MySqlDbType.VarChar, 45)
                    {
                        Value = TxtAuthor.Text
                    };
                    cmd.Parameters.Add(paramAuthor);
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar, 4)
                    {
                        Value = CboDivision.SelectedValue //b001b002
                    };
                    cmd.Parameters.Add(paramDivision);

                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 100)
                    {
                        Value = TxtNames.Text
                    };
                    cmd.Parameters.Add(paramNames);

                    MySqlParameter paramReleaseDate = new MySqlParameter("@ReleaseDate", MySqlDbType.Date)
                    {
                        Value = DtpReleaseDate.Value
                    };
                    cmd.Parameters.Add(paramReleaseDate);

                    MySqlParameter paramISBN = new MySqlParameter("@ISBN", MySqlDbType.VarChar, 13)
                    {
                        Value = TxtISBN.Text
                    };
                    cmd.Parameters.Add(paramISBN);

                    MySqlParameter paramPrice = new MySqlParameter("@Price", MySqlDbType.Decimal, 10)
                    {
                        Value = TxtPrice.Text
                    };
                    cmd.Parameters.Add(paramPrice);

                    //Primary Key
                    MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                    {
                        Value = TxtIdx.Text
                    };
                    cmd.Parameters.Add(paramIdx);


                    var result = cmd.ExecuteNonQuery();

                    if(MyMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다", "신규입력");
                    }
                    else if(MyMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정변경되었습니다", "수정변경");
                    }
                    else if(MyMode == BaseMode.DELETE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 삭제변경되었습니다", "삭제변경");
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateData();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtAuthor.Text = data.Cells[1].Value.ToString();

                // 로맨스, 추리 등 디스플레이 되는 글자로 인덱스 찾기
                // CboDivision.SelectedIndex = CboDivision.FindString(data.Cells[3].Value.ToString());
                // 코드 값을 그대로 할당
                CboDivision.SelectedValue = data.Cells[2].Value.ToString();

                TxtNames.Text = data.Cells[4].Value.ToString();
                //TODO:출간일 날짜 픽커 Cells[5]
                DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
                DtpReleaseDate.Format = DateTimePickerFormat.Custom;
                DtpReleaseDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());

                TxtISBN.Text = data.Cells[6].Value.ToString();
                TxtPrice.Text = data.Cells[7].Value.ToString();
                
                TxtIdx.ReadOnly = true;    // 연동된 DB의 Primary Key이기 때문에 절대 변경 불가

                MyMode = BaseMode.UPDATE;       // 수정모드로 변경
            }
        }

        private void TxtNames_Click(object sender, EventArgs e)
        {

        }

        private void GrdBooksTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}