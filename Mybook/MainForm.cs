using System;
using System.Windows.Forms;
using BookRentalShopApp20.Items;
using MetroFramework;
using MetroFramework.Forms;

namespace BookRentalShopApp20
{
    public partial class MainForm : MetroForm
    {
        #region 멤버변수
        public object FormWidowState { get; private set; }
        #endregion
        #region 생성자
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void MnuItemCodeMng_Click(object sender, EventArgs e)
        {
            DivMngForm form = new DivMngForm();
            ShowFormControl(form, "코드 관리");
        }

        private void MnuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnuItemBooksMng_Click(object sender, EventArgs e)
        {
            BooksMngForm form = new BooksMngForm();
            ShowFormControl(form, "도서 관리");
        }

        private void ShowFormControl(Form form, string title)
        {
            form.MdiParent = this;
            form.Text = title;
            form.Dock = DockStyle.Fill;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void MemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm();
            ShowFormControl(form, "회원 관리");
        }
        private void MenuRentalRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalMngForm form = new RentalMngForm();
            ShowFormControl(form, "대여 관리");
        }

        private void MenuUserUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            ShowFormControl(form, "사용자 관리");
        }
    }
}
