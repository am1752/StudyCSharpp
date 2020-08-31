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

namespace MtStockSystem.Subitems
{
    public partial class SearchItemForm : MetroForm

    {
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
            DgvSearchItems.Font = new Font("NanumGothic", 10, FontStyle.Regular);
            splitContainer1.SplitterDistance = 50;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };

        }
        private void SearchItemForm_Load_1(object sender, EventArgs e)
        {

        }

        private void MtlBack_Click(object sender, EventArgs e)
          {
                this.Visible = false;
            
                MainForm main = new MainForm();

                main.Location = this.Location;
                main.ShowDialog();

                this.Close();
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
