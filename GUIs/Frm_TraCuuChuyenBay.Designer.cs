namespace QuanLyBanVeMayBay.GUIs
{
    partial class Frm_TraCuuChuyenBay
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
            this.Pnl_Body = new System.Windows.Forms.Panel();
            this.Pnl_TraCuuChuyenBay = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cmb_TinhTrang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_TraCuu = new System.Windows.Forms.Button();
            this.Dtp_NgayDi = new System.Windows.Forms.DateTimePicker();
            this.Cmb_DiemDen = new System.Windows.Forms.ComboBox();
            this.Cmb_DiemDi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Pnl_Body.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Body
            // 
            this.Pnl_Body.Controls.Add(this.Pnl_TraCuuChuyenBay);
            this.Pnl_Body.Controls.Add(this.panel1);
            this.Pnl_Body.Location = new System.Drawing.Point(0, 4);
            this.Pnl_Body.Name = "Pnl_Body";
            this.Pnl_Body.Size = new System.Drawing.Size(1263, 668);
            this.Pnl_Body.TabIndex = 2;
            // 
            // Pnl_TraCuuChuyenBay
            // 
            this.Pnl_TraCuuChuyenBay.AutoScroll = true;
            this.Pnl_TraCuuChuyenBay.Location = new System.Drawing.Point(3, 81);
            this.Pnl_TraCuuChuyenBay.Name = "Pnl_TraCuuChuyenBay";
            this.Pnl_TraCuuChuyenBay.Size = new System.Drawing.Size(1257, 572);
            this.Pnl_TraCuuChuyenBay.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cmb_TinhTrang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Btn_TraCuu);
            this.panel1.Controls.Add(this.Dtp_NgayDi);
            this.panel1.Controls.Add(this.Cmb_DiemDen);
            this.panel1.Controls.Add(this.Cmb_DiemDi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 72);
            this.panel1.TabIndex = 0;
            // 
            // Cmb_TinhTrang
            // 
            this.Cmb_TinhTrang.FormattingEnabled = true;
            this.Cmb_TinhTrang.Items.AddRange(new object[] {
            "",
            "Đang bay",
            "Đã hoàn thành",
            "Bị trì hoãn",
            "Chưa cất cánh"});
            this.Cmb_TinhTrang.Location = new System.Drawing.Point(987, 18);
            this.Cmb_TinhTrang.Name = "Cmb_TinhTrang";
            this.Cmb_TinhTrang.Size = new System.Drawing.Size(134, 30);
            this.Cmb_TinhTrang.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(900, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tình trạng: ";
            // 
            // Btn_TraCuu
            // 
            this.Btn_TraCuu.Location = new System.Drawing.Point(1151, 11);
            this.Btn_TraCuu.Name = "Btn_TraCuu";
            this.Btn_TraCuu.Size = new System.Drawing.Size(99, 42);
            this.Btn_TraCuu.TabIndex = 6;
            this.Btn_TraCuu.Text = "Tra cứu";
            this.Btn_TraCuu.UseVisualStyleBackColor = true;
            this.Btn_TraCuu.Click += new System.EventHandler(this.Btn_TraCuu_Click);
            // 
            // Dtp_NgayDi
            // 
            this.Dtp_NgayDi.CustomFormat = "yyyy-MM-dd";
            this.Dtp_NgayDi.Location = new System.Drawing.Point(579, 18);
            this.Dtp_NgayDi.Name = "Dtp_NgayDi";
            this.Dtp_NgayDi.Size = new System.Drawing.Size(315, 30);
            this.Dtp_NgayDi.TabIndex = 5;
            // 
            // Cmb_DiemDen
            // 
            this.Cmb_DiemDen.FormattingEnabled = true;
            this.Cmb_DiemDen.Items.AddRange(new object[] {
            ""});
            this.Cmb_DiemDen.Location = new System.Drawing.Point(308, 18);
            this.Cmb_DiemDen.Name = "Cmb_DiemDen";
            this.Cmb_DiemDen.Size = new System.Drawing.Size(126, 30);
            this.Cmb_DiemDen.TabIndex = 4;
            // 
            // Cmb_DiemDi
            // 
            this.Cmb_DiemDi.FormattingEnabled = true;
            this.Cmb_DiemDi.Items.AddRange(new object[] {
            ""});
            this.Cmb_DiemDi.Location = new System.Drawing.Point(87, 18);
            this.Cmb_DiemDi.Name = "Cmb_DiemDi";
            this.Cmb_DiemDi.Size = new System.Drawing.Size(125, 30);
            this.Cmb_DiemDi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày khởi hành: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Điểm đến: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điểm đi: ";
            // 
            // Frm_TraCuuChuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 669);
            this.Controls.Add(this.Pnl_Body);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_TraCuuChuyenBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra Cứu Chuyến Bay";
            this.Load += new System.EventHandler(this.Frm_TraCuuChuyenBay_Load);
            this.Pnl_Body.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Body;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Pnl_TraCuuChuyenBay;
        private System.Windows.Forms.ComboBox Cmb_TinhTrang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_TraCuu;
        private System.Windows.Forms.DateTimePicker Dtp_NgayDi;
        private System.Windows.Forms.ComboBox Cmb_DiemDen;
        private System.Windows.Forms.ComboBox Cmb_DiemDi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

