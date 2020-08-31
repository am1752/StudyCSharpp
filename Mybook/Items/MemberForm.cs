using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BookRentalShopApp20.Items
{
    public partial class MemberForm : MetroForm
    {
        #region 멤버변수 영역
        BaseMode MyMode = BaseMode.NONE;    // 최초에는 기본상태
        readonly string strTblName = "membertbl";
        #endregion

        #region 생성자 영역
        public MemberForm()
        {
            InitializeComponent();
        }
        private void MemberTbl_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
        #endregion

        #region 이벤트 핸들러 영역
        //그리드 셀클릭 시 컨트롤에 셀 정보 띄우기
        private void GrbMemtbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrbMemtbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();

                int result = char.Parse(data.Cells[2].Value.ToString()) - 65 + 1;
                CboLevels.SelectedIndex = result; //회원등급 Cells[2]

                TxtAddr.Text = data.Cells[3].Value.ToString();
                TxtMobile.Text = data.Cells[4].Value.ToString();
                TxtEmail.Text = data.Cells[5].Value.ToString();

                TxtIdx.ReadOnly = true;    // 연동된 DB의 Primary Key이기 때문에 절대 변경 불가

                MyMode = BaseMode.UPDATE;
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
            InitControls();
        }

        // Btn신규 클릭
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtIdx.Text = TxtNames.Text = TxtAddr.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            TxtIdx.ReadOnly = false;
            CboLevels.SelectedIndex = 0;
            MyMode = BaseMode.INSERT;       
        }
        // Btn저장 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
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
            InitControls();

        }
        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        #region 커스텀 영역

        //업데이트 된 정보 그리드에 출력
        public void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Idx, " +
                                   "       Names, " +
                                   "       Levels, " +
                                   "       Addr, " +
                                   "       Mobile, " +
                                   "       Email " +
                                   "       FROM bookrentalshop.membertbl ";

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrbMemtbl.DataSource = ds;
                GrbMemtbl.DataMember = strTblName;
            }
            SetColumnHeaders();
        }
        //컬럼명 변경
        private void SetColumnHeaders()
        {
            DataGridViewColumn column;

            column = GrbMemtbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "번호";

            column = GrbMemtbl.Columns[1];
            column.Width = 100;
            column.HeaderText = "회원이름";

            column = GrbMemtbl.Columns[2];
            column.Width = 100;
            column.HeaderText = "등급";

            column = GrbMemtbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "주소";

            column = GrbMemtbl.Columns[4];
            column.Width = 150;
            column.HeaderText = "전화번호";

            column = GrbMemtbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "이메일";
        }


        //데이터 변경 DB에 반영
        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtNames.Text) ||
                CboLevels.SelectedIndex==0          ||
                string.IsNullOrEmpty(TxtAddr.Text)  ||
                string.IsNullOrEmpty(TxtMobile.Text)||
                string.IsNullOrEmpty(TxtEmail.Text))
            {
                MetroMessageBox.Show(this, " 빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MyMode == BaseMode.NONE)
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

                    if (MyMode == BaseMode.UPDATE || MyMode == BaseMode.INSERT)
                    {
                        if (MyMode == BaseMode.UPDATE)
                        {
                            cmd.CommandText = " UPDATE membertbl " +
                                              "    SET Names        = @Names, " +
                                              "        Levels       = @Levels, " +
                                              "        Addr         = @Addr, " +
                                              "        Mobile       = @Mobile, " +
                                              "        Email        = @Email " +
                                              "  WHERE Idx    = @Idx ";
                        }
                        else if (MyMode == BaseMode.INSERT)
                        {
                            cmd.CommandText = "INSERT INTO membertbl " +
                                              "( " +
                                                  "Names, " +
                                                  "Levels, " +
                                                  "Addr, " +
                                                  "Mobile, " +
                                                  "Email " +
                                              ") " +
                                              "VALUES " +
                                              "( " +
                                                "@Names, " +
                                                "@Levels, " +
                                                "@Addr, " +
                                                "@Mobile, " +
                                                "@Email " +
                                              "); ";

                        }
                        MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45)
                        {
                            Value = TxtNames.Text
                        };
                        cmd.Parameters.Add(paramNames);

                        MySqlParameter paramLevels = new MySqlParameter("@Levels", MySqlDbType.VarChar, 1)
                        {
                            Value = Convert.ToChar(CboLevels.SelectedIndex + 64)
                        };
                        cmd.Parameters.Add(paramLevels);

                        MySqlParameter paramAddr = new MySqlParameter("@Addr", MySqlDbType.VarChar, 100)
                        {
                            Value = TxtAddr.Text
                        };
                        cmd.Parameters.Add(paramAddr);

                        MySqlParameter paramMobile = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 13)
                        {
                            Value = TxtMobile.Text
                        };
                        cmd.Parameters.Add(paramMobile);

                        MySqlParameter paramEmail = new MySqlParameter("@Email", MySqlDbType.VarChar, 50)
                        {
                            Value = TxtEmail.Text
                        };
                        cmd.Parameters.Add(paramEmail);

                        if (MyMode == BaseMode.UPDATE)
                        {
                            //기본키
                            MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                            {
                                Value = TxtIdx.Text
                            };
                            cmd.Parameters.Add(paramIdx);
                        }
                    }
                    else if (MyMode == BaseMode.DELETE)
                    {
                        cmd.CommandText = "DELETE FROM membertbl " +
                                          "      WHERE Idx    = @Idx ";
                        MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                        {
                            Value = TxtIdx.Text
                        };
                        cmd.Parameters.Add(paramIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (MyMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다", "신규입력");
                    }
                    else if (MyMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정변경되었습니다", "수정변경");
                    }
                    else if (MyMode == BaseMode.DELETE)
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

        //컨트롤 초기화
        private void InitControls()
        {
            TxtIdx.Text = TxtNames.Text= TxtAddr.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            TxtIdx.Focus();

            CboLevels.SelectedIndex = 0;
            MyMode = BaseMode.NONE;
        }

        #endregion
    }
}
    
