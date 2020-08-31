using MetroFramework.Forms;
using MyStockSystem.SubItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStockSystem
{
    public partial class MainForm : MetroForm //Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void MtlsearchItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SearchItemForm search = new SearchItemForm();
            search.Location = this.Location;
            search.ShowDialog();
            this.Close();
        }

        private void MtlScockAnals_Click(object sender, EventArgs e)
        {

        }

        private void MtlInvestSimul_Click(object sender, EventArgs e)
        {

        }

        private void MtlGalmetgilGuide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GalmetgilForm search = new GalmetgilForm();
            search.Location = this.Location;
            search.ShowDialog();
            this.Close();

        }
    }
}
