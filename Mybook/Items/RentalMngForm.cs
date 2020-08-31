using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp20.Items
{
    public partial class RentalMngForm : MetroForm
    {

        #region 멤버변수 영역
        BaseMode MyMode = BaseMode.NONE;    // 최초에는 기본상태
        readonly string strTblName = "membertbl";
        #endregion

        #region 생성자 영역
        public RentalMngForm()
        {
            InitializeComponent();
        }

        private void RentalMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboBook();
            UpdateComboMember();
            UpdateData();
        }

        #endregion

        #region 이벤트 핸들러 영역
        //그리드 셀클릭 시 컨트롤에 셀 정보 띄우기


        private void GrbMemtbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //DataGridViewRow data = Rentaltbl.Rows[e.RowIndex];
                //TxtIdx.Text = data.Cells[0].Value.ToString();
                //TxtNames.Text = data.Cells[1].Value.ToString();

                //int result = char.Parse(data.Cells[2].Value.ToString()) - 65 + 1;
                //CboMember.SelectedIndex = result; //회원등급 Cells[2]

                //TxtAddr.Text = data.Cells[3].Value.ToString();
                //TxtMobile.Text = data.Cells[4].Value.ToString();
                //TxtEmail.Text = data.Cells[5].Value.ToString();

                //TxtIdx.ReadOnly = true;    // 연동된 DB의 Primary Key이기 때문에 절대 변경 불가

                //MyMode = BaseMode.UPDATE;
            }
        }
        // Btn삭제 클릭
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            MyMode = BaseMode.DELETE;
            SaveData();
            //InitControls();
        }

        // Btn신규 클릭
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //TxtIdx.Text = TxtNames.Text = TxtAddr.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            //TxtIdx.ReadOnly = false;
            //CboMember.SelectedIndex = 0;
            //MyMode = BaseMode.INSERT;
        }
        // Btn저장 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();

            UpdateComboBook();
            UpdateComboMember();
            UpdateData();

        }

        // Btn취소 클릭
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MyMode == BaseMode.NONE)
            {
                var result = MetroMessageBox.Show(this, "회원관리 창을 닫으시겠습니까?", "작업 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            //InitControls();

        }
        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        #region 커스텀 영역
        private void UpdateComboMember()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Idx, Names FROM membertbl ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }
                CboMember.DataSource = new BindingSource(temps, null);

                CboMember.DisplayMember = "Key";
                CboMember.ValueMember = "Value";
                CboMember.SelectedIndex = 0;

            }
        }
        private void UpdateComboBook()
        {

            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $" SELECT Idx, Names, (SELECT Names FROM divtbl WHERE Division = b.Division) as Division " +
                                    "FROM BooksTbl as b ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add($"{reader[2]} {reader[1]}", $"{reader[0]}");

                }
                CboBook.DataSource = new BindingSource(temps, null);

                CboBook.DisplayMember = "Key";
                CboBook.ValueMember = "Value";
                CboBook.SelectedIndex = 0;

            }

        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = "    SELECT r.idx AS '대여번호', " +
                                          "m.Names AS '대여회원', " +
                                          "b.Names AS '대여책제목', " +
                                          "b.ISBN, " +
                                          "r.rentalDate AS '대여일', " +
                                          "r.memberIdx, " +
                                          "r.bookIdx " +
                                        "FROM rentaltbl AS r " +
                                  "INNER JOIN membertbl AS m " +
                                  "        ON r.memberIdx = m.Idx " +
                                  "INNER JOIN bookstbl AS b " +
                                  "        ON r.bookIdx = b.Idx ";

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                Rentaltbl.DataSource = ds;
                Rentaltbl.DataMember = strTblName;
            }

            //SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            //DataGridViewColumn column;

            //column = GrdDivTbl.Columns[0];
            //column.Width = 100;
            //column.HeaderText = "구분코드";

            //column = GrdDivTbl.Columns[1];
            //column.Width = 150;
            //column.HeaderText = "이름";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MyMode != BaseMode.UPDATE)
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
            //TxtDivision.Text = TxtNames.Text = string.Empty;
            //TxtDivision.Focus();
        }

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

        //private void BtnNew_Click(object sender, EventArgs e)
        //{
        //    TxtDivision.Text = TxtNames.Text = string.Empty;
        //    TxtDivision.ReadOnly = false;

        //    MyMode = BaseMode.INSERT;       // 신규입력모드
        //}

        private void SaveData()
        {
            //if (string.IsNullOrEmpty(TxtDivision.Text))
            //{
            //    MetroMessageBox.Show(this, " 빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (MyMode == BaseMode.NONE)
            //{
            //    MetroMessageBox.Show(this, "신규등록버튼을 누르고 신규등록하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //try
            //{
            //    using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            //    {
            //        conn.Open();
            //        MySqlCommand cmd = new MySqlCommand();
            //        cmd.Connection = conn;

            //        if (MyMode == BaseMode.UPDATE)

            //        {
            //            cmd.CommandText = "UPDATE divtbl " +
            //                          "   SET Names = @Names " +
            //                          " WHERE Division = @Division ";
            //        }
            //        else if (MyMode == BaseMode.INSERT)
            //        {
            //            cmd.CommandText = " INSERT INTO " +
            //                              " divtbl (Division, Names) " +
            //                              " VALUES (@Division, @Names) ";
            //        }
            //        else if (MyMode == BaseMode.DELETE)
            //        {
            //            cmd.CommandText = "DELETE FROM divtbl " +
            //                              " WHERE Division = @Division ";
            //        }

            //        if (MyMode == BaseMode.INSERT || MyMode == BaseMode.UPDATE)
            //        {
            //            MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
            //            paramNames.Value = TxtNames.Text;
            //            cmd.Parameters.Add(paramNames);
            //        }


            //        MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
            //        paramDivision.Value = TxtDivision.Text;
            //        cmd.Parameters.Add(paramDivision);

            //        var result = cmd.ExecuteNonQuery();

            //        if (MyMode == BaseMode.INSERT)
            //        {
            //            MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다", "신규입력");
            //        }
            //        else if (MyMode == BaseMode.UPDATE)
            //        {
            //            MetroMessageBox.Show(this, $"{result}건이 수정변경되었습니다", "수정변경");
            //        }
            //        else if (MyMode == BaseMode.DELETE)
            //        {
            //            MetroMessageBox.Show(this, $"{result}건이 삭제변경되었습니다", "삭제변경");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    UpdateData();
            //}
        }

        //private void BtnSave_Click(object sender, EventArgs e)
        //{
        //    SaveData();
        //}

        //private void BtnCancel_Click(object sender, EventArgs e)
        //{

        //}

        //private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
        //        TxtDivision.Text = data.Cells[0].Value.ToString();
        //        TxtNames.Text = data.Cells[1].Value.ToString();

        //        TxtDivision.ReadOnly = true;    // 연동된 DB의 Primary Key이기 때문에 절대 변경 불가

        //        MyMode = BaseMode.UPDATE;       // 수정모드로 변경
        //    }
        //}

        //private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{


        //}
        private void metroLabel3_Click()
        { }
    }
    #endregion
}