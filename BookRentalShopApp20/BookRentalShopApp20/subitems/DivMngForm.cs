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

namespace BookRentalShopApp20.subitems
{
    public partial class DivMngForm : MetroForm
    {
        //private readonly string strConnectingString = "Data Source=localhost;Port=3306;Database=bookRentalshop;Uid=root;Password=mysql_p@ssw0rd";
        readonly string strTblName = "divTbl";

        BaseMode MyMode = BaseMode.None;

        public DivMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {  
            UpdateData();
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Division, Names FROM {strTblName};";
                conn.Open();
                //MetroMessageBox.Show(this, $"DB접속성공!!");
                //MySqlCommand cmd = new MySqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = strQuery;

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery,conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = strTblName;
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            DataGridViewColumn column;

            column = GrdDivTbl.Columns[0];

            column.Width = 100;
            column.HeaderText = "구분코드";

            column = GrdDivTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "이름";
        
           
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtDivision.Text = Txtnames.Text = string.Empty;
            TxtDivision.ReadOnly = false;
            MyMode = BaseMode.INSERT;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
           
        }

        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                MetroMessageBox.Show(this, " 빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*
            if(MyMode != BaseMode.INSERT || MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "신규등록버튼을 누르고 신규등록하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (MyMode == BaseMode.UPDATE)

                    {
                        cmd.CommandText = "UPDATE divtbl " +
                                      "   SET Names = @Names " +
                                      " WHERE Division = @Division ";
                    }
                    else if (MyMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = " INSERT INTO " +
                                          " divtbl (Division, Names) " +
                                          " VALUES (@Division, @Name) ";
                    }

                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                    paramNames.Value = Txtnames.Text;
                    cmd.Parameters.Add(paramNames);
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
                    paramDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();

                    if (MyMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다", "신규입력");
                    }

                    else if (MyMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정변경되었습니다", "수정변경");
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


        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtDivision.Text = data.Cells[0].Value.ToString();
                Txtnames.Text = data.Cells[1].Value.ToString();

                TxtDivision.ReadOnly = true;

                myMode = BaseMode.UPDATE;
            }
        }

        private void GrdDivTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
