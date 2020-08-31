using MetroFramework.Forms;
using MtStockSystem.Subitems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtStockSystem
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2,
                Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            

        }

        private void MtlSearchItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SearchItemForm seachItem = new SearchItemForm();
            seachItem.Location = this.Location;
            seachItem.ShowDialog();

            this.Close();
        }
    }
}
