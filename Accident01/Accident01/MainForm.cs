using Accident01.sub;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Accident01
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SubForm search = new SubForm();
            search.Location = this.Location;
            search.ShowDialog();
            this.Close();

        }
    }
}
