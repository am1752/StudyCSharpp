namespace MyStockSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MtlInvestSimul = new MetroFramework.Controls.MetroTile();
            this.MtlScockAnals = new MetroFramework.Controls.MetroTile();
            this.MtlGalmetgilGuide = new MetroFramework.Controls.MetroTile();
            this.MtlSearchItem = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // MtlInvestSimul
            // 
            this.MtlInvestSimul.Location = new System.Drawing.Point(335, 251);
            this.MtlInvestSimul.Name = "MtlInvestSimul";
            this.MtlInvestSimul.Size = new System.Drawing.Size(300, 149);
            this.MtlInvestSimul.Style = MetroFramework.MetroColorStyle.Orange;
            this.MtlInvestSimul.TabIndex = 2;
            this.MtlInvestSimul.Text = "투자 시뮬레이션";
            this.MtlInvestSimul.TileImage = global::MyStockSystem.Properties.Resources.simulator2;
            this.MtlInvestSimul.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlInvestSimul.UseTileImage = true;
            this.MtlInvestSimul.Click += new System.EventHandler(this.MtlInvestSimul_Click);
            // 
            // MtlScockAnals
            // 
            this.MtlScockAnals.Location = new System.Drawing.Point(335, 95);
            this.MtlScockAnals.Name = "MtlScockAnals";
            this.MtlScockAnals.Size = new System.Drawing.Size(150, 149);
            this.MtlScockAnals.Style = MetroFramework.MetroColorStyle.Yellow;
            this.MtlScockAnals.TabIndex = 1;
            this.MtlScockAnals.Text = "주식 정보 분석";
            this.MtlScockAnals.TileImage = global::MyStockSystem.Properties.Resources.analysis2;
            this.MtlScockAnals.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlScockAnals.UseTileImage = true;
            this.MtlScockAnals.Click += new System.EventHandler(this.MtlScockAnals_Click);
            // 
            // MtlGalmetgilGuide
            // 
            this.MtlGalmetgilGuide.Location = new System.Drawing.Point(491, 95);
            this.MtlGalmetgilGuide.Name = "MtlGalmetgilGuide";
            this.MtlGalmetgilGuide.Size = new System.Drawing.Size(300, 149);
            this.MtlGalmetgilGuide.Style = MetroFramework.MetroColorStyle.Pink;
            this.MtlGalmetgilGuide.TabIndex = 0;
            this.MtlGalmetgilGuide.Text = "갈맷길 정보";
            this.MtlGalmetgilGuide.TileImage = global::MyStockSystem.Properties.Resources.seagull2;
            this.MtlGalmetgilGuide.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlGalmetgilGuide.UseTileImage = true;
            this.MtlGalmetgilGuide.Click += new System.EventHandler(this.MtlGalmetgilGuide_Click);
            // 
            // MtlSearchItem
            // 
            this.MtlSearchItem.Location = new System.Drawing.Point(29, 95);
            this.MtlSearchItem.Name = "MtlSearchItem";
            this.MtlSearchItem.Size = new System.Drawing.Size(300, 149);
            this.MtlSearchItem.Style = MetroFramework.MetroColorStyle.Green;
            this.MtlSearchItem.TabIndex = 0;
            this.MtlSearchItem.Text = "주식 정보 검색";
            this.MtlSearchItem.TileImage = global::MyStockSystem.Properties.Resources.marketing2;
            this.MtlSearchItem.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlSearchItem.UseTileImage = true;
            this.MtlSearchItem.Click += new System.EventHandler(this.MtlsearchItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MtlInvestSimul);
            this.Controls.Add(this.MtlScockAnals);
            this.Controls.Add(this.MtlGalmetgilGuide);
            this.Controls.Add(this.MtlSearchItem);
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(26, 65, 26, 21);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "주식 분석 시스템";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile MtlSearchItem;
        private MetroFramework.Controls.MetroTile MtlScockAnals;
        private MetroFramework.Controls.MetroTile MtlInvestSimul;
        private MetroFramework.Controls.MetroTile MtlGalmetgilGuide;
    }
}

