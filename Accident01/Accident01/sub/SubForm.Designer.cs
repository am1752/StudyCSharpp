namespace Accident01.sub
{
    partial class SubForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sido_sgg_nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occrrnc_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caslt_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dth_dnv_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.se_dnv_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl_dnv_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.SIDO = new System.Windows.Forms.ComboBox();
            this.DOSI = new System.Windows.Forms.ComboBox();
            this.CBO = new System.Windows.Forms.Button();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.splitContainer1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(12, 55);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(816, 458);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            this.metroPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.metroPanel1_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CBO);
            this.splitContainer1.Panel1.Controls.Add(this.DOSI);
            this.splitContainer1.Panel1.Controls.Add(this.SIDO);
            this.splitContainer1.Panel1.Controls.Add(this.metroTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.metroButton1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(816, 458);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 2;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(483, 10);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(200, 40);
            this.metroTextBox1.TabIndex = 1;
            this.metroTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click);
            this.metroTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.metroTextBox1_KeyPress);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(689, 8);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(76, 44);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "검색";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sido_sgg_nm,
            this.occrrnc_cnt,
            this.caslt_cnt,
            this.dth_dnv_cnt,
            this.se_dnv_cnt,
            this.sl_dnv_cnt});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(816, 382);
            this.dataGridView1.TabIndex = 0;
            // 
            // sido_sgg_nm
            // 
            this.sido_sgg_nm.HeaderText = "시도시군구명";
            this.sido_sgg_nm.Name = "sido_sgg_nm";
            // 
            // occrrnc_cnt
            // 
            this.occrrnc_cnt.HeaderText = "발생건수";
            this.occrrnc_cnt.Name = "occrrnc_cnt";
            // 
            // caslt_cnt
            // 
            this.caslt_cnt.HeaderText = "사상자수";
            this.caslt_cnt.Name = "caslt_cnt";
            // 
            // dth_dnv_cnt
            // 
            this.dth_dnv_cnt.HeaderText = "사망자수";
            this.dth_dnv_cnt.Name = "dth_dnv_cnt";
            // 
            // se_dnv_cnt
            // 
            this.se_dnv_cnt.HeaderText = "중상자수";
            this.se_dnv_cnt.Name = "se_dnv_cnt";
            // 
            // sl_dnv_cnt
            // 
            this.sl_dnv_cnt.HeaderText = "경상자수";
            this.sl_dnv_cnt.Name = "sl_dnv_cnt";
            // 
            // metroTile1
            // 
            this.metroTile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.metroTile1.CustomBackground = true;
            this.metroTile1.Location = new System.Drawing.Point(774, 519);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(54, 36);
            this.metroTile1.TabIndex = 1;
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // SIDO
            // 
            this.SIDO.FormattingEnabled = true;
            this.SIDO.Items.AddRange(new object[] {
            "서울시",
            "부산시",
            "대구시",
            "인천시",
            "광주시",
            "대전시",
            "울산시",
            "경기도",
            "강원도",
            "충청북도",
            "충청남도",
            "전라북도",
            "전라남도",
            "경상북도",
            "경상남도",
            "제주도",
            "세종시"});
            this.SIDO.Location = new System.Drawing.Point(36, 29);
            this.SIDO.Name = "SIDO";
            this.SIDO.Size = new System.Drawing.Size(121, 20);
            this.SIDO.TabIndex = 2;
            this.SIDO.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DOSI
            // 
            this.DOSI.FormattingEnabled = true;
            this.DOSI.Location = new System.Drawing.Point(181, 29);
            this.DOSI.Name = "DOSI";
            this.DOSI.Size = new System.Drawing.Size(121, 20);
            this.DOSI.TabIndex = 3;
            this.DOSI.SelectedIndexChanged += new System.EventHandler(this.DOSI_SelectedIndexChanged);
            // 
            // CBO
            // 
            this.CBO.Location = new System.Drawing.Point(331, 25);
            this.CBO.Name = "CBO";
            this.CBO.Size = new System.Drawing.Size(75, 23);
            this.CBO.TabIndex = 4;
            this.CBO.Text = "검색";
            this.CBO.UseVisualStyleBackColor = true;
            this.CBO.Click += new System.EventHandler(this.CBO_Click);
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 578);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "SubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.SubForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sido_sgg_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn occrrnc_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn caslt_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dth_dnv_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn se_dnv_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl_dnv_cnt;
        private System.Windows.Forms.ComboBox DOSI;
        private System.Windows.Forms.ComboBox SIDO;
        private System.Windows.Forms.Button CBO;
    }
}