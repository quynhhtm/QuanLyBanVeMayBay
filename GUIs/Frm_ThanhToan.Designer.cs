namespace QuanLyBanVeMayBay.GUIs
{
    partial class Frm_ThanhToan
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
            this.components = new System.ComponentModel.Container();
            this.Pnl_NganHang = new System.Windows.Forms.Panel();
            this.Lbl_HanhKhach = new System.Windows.Forms.Label();
            this.Btn_Xong = new System.Windows.Forms.Button();
            this.Lbl_NganHang3 = new System.Windows.Forms.Label();
            this.Lbl_NganHang2 = new System.Windows.Forms.Label();
            this.Lbl_NganHang1 = new System.Windows.Forms.Label();
            this.Lbl_ThoiGianThanhToan = new System.Windows.Forms.Label();
            this.Tmr_ThoiGianConLai = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.Pnl_HanhTrinh = new System.Windows.Forms.Panel();
            this.Pnl_ChiTietChuyenBay = new System.Windows.Forms.Panel();
            this.Lbl_ChiTietChuyenBay = new System.Windows.Forms.Label();
            this.Pnl_NganHang.SuspendLayout();
            this.panel6.SuspendLayout();
            this.Pnl_ChiTietChuyenBay.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_NganHang
            // 
            this.Pnl_NganHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_NganHang.Controls.Add(this.Lbl_HanhKhach);
            this.Pnl_NganHang.Controls.Add(this.Btn_Xong);
            this.Pnl_NganHang.Controls.Add(this.Lbl_NganHang3);
            this.Pnl_NganHang.Controls.Add(this.Lbl_NganHang2);
            this.Pnl_NganHang.Controls.Add(this.Lbl_NganHang1);
            this.Pnl_NganHang.Controls.Add(this.Lbl_ThoiGianThanhToan);
            this.Pnl_NganHang.Location = new System.Drawing.Point(12, 12);
            this.Pnl_NganHang.Name = "Pnl_NganHang";
            this.Pnl_NganHang.Size = new System.Drawing.Size(770, 652);
            this.Pnl_NganHang.TabIndex = 0;
            // 
            // Lbl_HanhKhach
            // 
            this.Lbl_HanhKhach.AutoSize = true;
            this.Lbl_HanhKhach.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_HanhKhach.ForeColor = System.Drawing.Color.Teal;
            this.Lbl_HanhKhach.Location = new System.Drawing.Point(4, 5);
            this.Lbl_HanhKhach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_HanhKhach.Name = "Lbl_HanhKhach";
            this.Lbl_HanhKhach.Size = new System.Drawing.Size(352, 32);
            this.Lbl_HanhKhach.TabIndex = 26;
            this.Lbl_HanhKhach.Text = "Ngân hàng nhận thanh toán";
            // 
            // Btn_Xong
            // 
            this.Btn_Xong.Location = new System.Drawing.Point(296, 456);
            this.Btn_Xong.Name = "Btn_Xong";
            this.Btn_Xong.Size = new System.Drawing.Size(119, 36);
            this.Btn_Xong.TabIndex = 4;
            this.Btn_Xong.Text = "Xong";
            this.Btn_Xong.UseVisualStyleBackColor = true;
            this.Btn_Xong.Click += new System.EventHandler(this.Btn_Xong_Click);
            // 
            // Lbl_NganHang3
            // 
            this.Lbl_NganHang3.Location = new System.Drawing.Point(3, 323);
            this.Lbl_NganHang3.Name = "Lbl_NganHang3";
            this.Lbl_NganHang3.Size = new System.Drawing.Size(762, 95);
            this.Lbl_NganHang3.TabIndex = 3;
            this.Lbl_NganHang3.Text = "Ngân hàng: CCC \n STK: ZZZ.ZZZ.ZZZ \n Đơn vị thụ hưởng: HANG HANG KHONG UTE";
            this.Lbl_NganHang3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_NganHang2
            // 
            this.Lbl_NganHang2.Location = new System.Drawing.Point(3, 190);
            this.Lbl_NganHang2.Name = "Lbl_NganHang2";
            this.Lbl_NganHang2.Size = new System.Drawing.Size(766, 95);
            this.Lbl_NganHang2.TabIndex = 2;
            this.Lbl_NganHang2.Text = "Ngân hàng: BBB \n STK: YYY.YYY.YYY \n Đơn vị thụ hưởng: HANG HANG KHONG UTE";
            this.Lbl_NganHang2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_NganHang1
            // 
            this.Lbl_NganHang1.Location = new System.Drawing.Point(3, 57);
            this.Lbl_NganHang1.Name = "Lbl_NganHang1";
            this.Lbl_NganHang1.Size = new System.Drawing.Size(766, 95);
            this.Lbl_NganHang1.TabIndex = 1;
            this.Lbl_NganHang1.Text = "Ngân hàng: AAA \n STK: XXX.XXX.XXX \n Đơn vị thụ hưởng: HANG HANG KHONG UTE";
            this.Lbl_NganHang1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_ThoiGianThanhToan
            // 
            this.Lbl_ThoiGianThanhToan.AutoSize = true;
            this.Lbl_ThoiGianThanhToan.Location = new System.Drawing.Point(6, 624);
            this.Lbl_ThoiGianThanhToan.Name = "Lbl_ThoiGianThanhToan";
            this.Lbl_ThoiGianThanhToan.Size = new System.Drawing.Size(56, 22);
            this.Lbl_ThoiGianThanhToan.TabIndex = 0;
            this.Lbl_ThoiGianThanhToan.Text = "10:00";
            // 
            // Tmr_ThoiGianConLai
            // 
            this.Tmr_ThoiGianConLai.Enabled = true;
            this.Tmr_ThoiGianConLai.Interval = 1000;
            this.Tmr_ThoiGianConLai.Tick += new System.EventHandler(this.Tmr_ThoiGianThanhToan_Tick);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.Pnl_HanhTrinh);
            this.panel6.Controls.Add(this.Pnl_ChiTietChuyenBay);
            this.panel6.Location = new System.Drawing.Point(788, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(462, 649);
            this.panel6.TabIndex = 30;
            // 
            // Pnl_HanhTrinh
            // 
            this.Pnl_HanhTrinh.AutoScroll = true;
            this.Pnl_HanhTrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_HanhTrinh.Location = new System.Drawing.Point(0, 60);
            this.Pnl_HanhTrinh.Name = "Pnl_HanhTrinh";
            this.Pnl_HanhTrinh.Size = new System.Drawing.Size(460, 587);
            this.Pnl_HanhTrinh.TabIndex = 1;
            // 
            // Pnl_ChiTietChuyenBay
            // 
            this.Pnl_ChiTietChuyenBay.Controls.Add(this.Lbl_ChiTietChuyenBay);
            this.Pnl_ChiTietChuyenBay.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_ChiTietChuyenBay.Location = new System.Drawing.Point(0, 0);
            this.Pnl_ChiTietChuyenBay.Name = "Pnl_ChiTietChuyenBay";
            this.Pnl_ChiTietChuyenBay.Size = new System.Drawing.Size(460, 60);
            this.Pnl_ChiTietChuyenBay.TabIndex = 0;
            // 
            // Lbl_ChiTietChuyenBay
            // 
            this.Lbl_ChiTietChuyenBay.AutoSize = true;
            this.Lbl_ChiTietChuyenBay.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ChiTietChuyenBay.ForeColor = System.Drawing.Color.Teal;
            this.Lbl_ChiTietChuyenBay.Location = new System.Drawing.Point(13, 18);
            this.Lbl_ChiTietChuyenBay.Name = "Lbl_ChiTietChuyenBay";
            this.Lbl_ChiTietChuyenBay.Size = new System.Drawing.Size(247, 32);
            this.Lbl_ChiTietChuyenBay.TabIndex = 24;
            this.Lbl_ChiTietChuyenBay.Text = "Chi tiết chuyến bay";
            // 
            // Frm_ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.Pnl_NganHang);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ThanhToan";
            this.Load += new System.EventHandler(this.Frm_ThanhToan_Load);
            this.Pnl_NganHang.ResumeLayout(false);
            this.Pnl_NganHang.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.Pnl_ChiTietChuyenBay.ResumeLayout(false);
            this.Pnl_ChiTietChuyenBay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_NganHang;
        private System.Windows.Forms.Timer Tmr_ThoiGianConLai;
        private System.Windows.Forms.Label Lbl_ThoiGianThanhToan;
        private System.Windows.Forms.Label Lbl_NganHang1;
        private System.Windows.Forms.Label Lbl_NganHang2;
        private System.Windows.Forms.Label Lbl_NganHang3;
        private System.Windows.Forms.Button Btn_Xong;
        private System.Windows.Forms.Label Lbl_HanhKhach;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel Pnl_HanhTrinh;
        private System.Windows.Forms.Panel Pnl_ChiTietChuyenBay;
        private System.Windows.Forms.Label Lbl_ChiTietChuyenBay;
    }
}