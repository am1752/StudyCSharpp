using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace BookRentalShopApp20.Items
{
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {
            if (string.IsNullOrEmpty(TxtUserId.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            // if (TxtUserId.Text == "" || TxtUserId.Text == null || TxtPassword.Text == null || TxtPassword.Text == "")
            {
                MetroMessageBox.Show(this, "아이디, 패스워드를 입력하세요", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUserId.Focus();
                return;
            }

            // 실제 DB처리
            string resultId = string.Empty;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();
                    // MetroMessageBox.Show(this, "DB접속성공");
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT userID FROM userTBL " +
                                      " WHERE userID = @userID " +
                                      "   AND password = @password ";   // 띄어쓰기, 줄을 맞춰주지않으면 syntax에러발생

                    MySqlParameter paramUserId = new MySqlParameter("@userID", MySqlDbType.VarChar, 12);
                    paramUserId.Value = TxtUserId.Text.Trim();
                    MySqlParameter paramPassword = new MySqlParameter("@password", MySqlDbType.VarChar);
                    
                    var md5Hash = MD5.Create();
                    var cryptoPassword = Commons.GetMd5Hash(md5Hash, TxtPassword.Text.Trim());
                    //MD5는 단방향
                    paramPassword.Value = cryptoPassword;

                    cmd.Parameters.Add(paramUserId);
                    cmd.Parameters.Add(paramPassword);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (!reader.HasRows)
                    {
                        MetroMessageBox.Show(this, "아이디, 패스워드를 정확하게 입력하세요", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtUserId.Text = TxtPassword.Text = string.Empty;
                        TxtUserId.Focus();
                        return;
                    }
                    else
                    {
                        resultId = reader["userID"] != null ? reader["userID"].ToString() : string.Empty;
                        MetroMessageBox.Show(this, $"{resultId} 로그인성공");
                    }
                }
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"DB접속에러 : {ex.Message}", "로그인 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(string.IsNullOrEmpty(resultId))
            {
                MetroMessageBox.Show(this, "아이디, 패스워드를 정확하게 입력하세요", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUserId.Text = TxtPassword.Text = string.Empty;
                TxtUserId.Focus();
                return;
            }
            else
            {
                this.Close();
            }
                
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (e.KeyChar == 13) BtnOk_Click(sender, new EventArgs());
            }
        }
    }
}
