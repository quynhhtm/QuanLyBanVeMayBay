namespace QuanLyBanVeMayBay.GUIs
{
    partial class Frm_QuanLyNguoiDung
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
            this.Pnl_ThongTinHoaDon = new System.Windows.Forms.Panel();
            this.Pnl_DanhSachHoaDon = new System.Windows.Forms.Panel();
            this.Btn_TraCuu = new System.Windows.Forms.Button();
            this.Txt_SoDienThoaiTraCuu = new System.Windows.Forms.TextBox();
            this.Pnl_ThongTinCaNhan = new System.Windows.Forms.Panel();
            this.Txt_MaNguoiDung = new System.Windows.Forms.TextBox();
            this.Lbl_MaNguoiDung = new System.Windows.Forms.Label();
            this.Txt_Email = new System.Windows.Forms.TextBox();
            this.Txt_HoTen = new System.Windows.Forms.TextBox();
            this.Lbl_Email = new System.Windows.Forms.Label();
            this.Lbl_HoTen = new System.Windows.Forms.Label();
            this.Pnl_ThongTinHoaDon.SuspendLayout();
            this.Pnl_ThongTinCaNhan.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_ThongTinHoaDon
            // 
            this.Pnl_ThongTinHoaDon.Controls.Add(this.Pnl_DanhSachHoaDon);
            this.Pnl_ThongTinHoaDon.Controls.Add(this.Btn_TraCuu);
            this.Pnl_ThongTinHoaDon.Controls.Add(this.Txt_SoDienThoaiTraCuu);
            this.Pnl_ThongTinHoaDon.Location = new System.Drawing.Point(12, 12);
            this.Pnl_ThongTinHoaDon.Name = "Pnl_ThongTinHoaDon";
            this.Pnl_ThongTinHoaDon.Size = new System.Drawing.Size(844, 649);
            this.Pnl_ThongTinHoaDon.TabIndex = 6;
            // 
            // Pnl_DanhSachHoaDon
            // 
            this.Pnl_DanhSachHoaDon.AutoScroll = true;
            this.Pnl_DanhSachHoaDon.Location = new System.Drawing.Point(2, 39);
            this.Pnl_DanhSachHoaDon.Name = "Pnl_DanhSachHoaDon";
            this.Pnl_DanhSachHoaDon.Size = new System.Drawing.Size(841, 607);
            this.Pnl_DanhSachHoaDon.TabIndex = 10;
            // 
            // Btn_TraCuu
            // 
            this.Btn_TraCuu.Location = new System.Drawing.Point(538, 2);
            this.Btn_TraCuu.Name = "Btn_TraCuu";
            this.Btn_TraCuu.Size = new System.Drawing.Size(165, 36);
            this.Btn_TraCuu.TabIndex = 9;
            this.Btn_TraCuu.Text = "Tra cứu ";
            this.Btn_TraCuu.UseVisualStyleBackColor = true;
            this.Btn_TraCuu.Click += new System.EventHandler(this.Btn_TraCuu_Click);
            // 
            // Txt_SoDienThoaiTraCuu
            // 
            this.Txt_SoDienThoaiTraCuu.Location = new System.Drawing.Point(6, 5);
            this.Txt_SoDienThoaiTraCuu.Name = "Txt_SoDienThoaiTraCuu";
            this.Txt_SoDienThoaiTraCuu.Size = new System.Drawing.Size(394, 30);
            this.Txt_SoDienThoaiTraCuu.TabIndex = 8;
            this.Txt_SoDienThoaiTraCuu.Text = "Số điện thoại";
            this.Txt_SoDienThoaiTraCuu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pnl_ThongTinCaNhan
            // 
            this.Pnl_ThongTinCaNhan.Controls.Add(this.Txt_MaNguoiDung);
            this.Pnl_ThongTinCaNhan.Controls.Add(this.Lbl_MaNguoiDung);
            this.Pnl_ThongTinCaNhan.Controls.Add(this.Txt_Email);
            this.Pnl_ThongTinCaNhan.Controls.Add(this.Txt_HoTen);
            this.Pnl_ThongTinCaNhan.Controls.Add(this.Lbl_Email);
            this.Pnl_ThongTinCaNhan.Controls.Add(this.Lbl_HoTen);
            this.Pnl_ThongTinCaNhan.Location = new System.Drawing.Point(856, 12);
            this.Pnl_ThongTinCaNhan.Name = "Pnl_ThongTinCaNhan";
            this.Pnl_ThongTinCaNhan.Size = new System.Drawing.Size(398, 649);
            this.Pnl_ThongTinCaNhan.TabIndex = 8;
            // 
            // Txt_MaNguoiDung
            // 
            this.Txt_MaNguoiDung.Location = new System.Drawing.Point(167, 5);
            this.Txt_MaNguoiDung.Name = "Txt_MaNguoiDung";
            this.Txt_MaNguoiDung.ReadOnly = true;
            this.Txt_MaNguoiDung.Size = new System.Drawing.Size(216, 30);
            this.Txt_MaNguoiDung.TabIndex = 7;
            this.Txt_MaNguoiDung.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lbl_MaNguoiDung
            // 
            this.Lbl_MaNguoiDung.AutoSize = true;
            this.Lbl_MaNguoiDung.Location = new System.Drawing.Point(16, 9);
            this.Lbl_MaNguoiDung.Name = "Lbl_MaNguoiDung";
            this.Lbl_MaNguoiDung.Size = new System.Drawing.Size(130, 22);
            this.Lbl_MaNguoiDung.TabIndex = 6;
            this.Lbl_MaNguoiDung.Text = "Mã người dùng";
            // 
            // Txt_Email
            // 
            this.Txt_Email.Location = new System.Drawing.Point(167, 86);
            this.Txt_Email.Name = "Txt_Email";
            this.Txt_Email.ReadOnly = true;
            this.Txt_Email.Size = new System.Drawing.Size(216, 30);
            this.Txt_Email.TabIndex = 5;
            this.Txt_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_HoTen
            // 
            this.Txt_HoTen.Location = new System.Drawing.Point(167, 44);
            this.Txt_HoTen.Name = "Txt_HoTen";
            this.Txt_HoTen.ReadOnly = true;
            this.Txt_HoTen.Size = new System.Drawing.Size(216, 30);
            this.Txt_HoTen.TabIndex = 3;
            this.Txt_HoTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lbl_Email
            // 
            this.Lbl_Email.AutoSize = true;
            this.Lbl_Email.Location = new System.Drawing.Point(16, 90);
            this.Lbl_Email.Name = "Lbl_Email";
            this.Lbl_Email.Size = new System.Drawing.Size(57, 22);
            this.Lbl_Email.TabIndex = 2;
            this.Lbl_Email.Text = "Email";
            // 
            // Lbl_HoTen
            // 
            this.Lbl_HoTen.AutoSize = true;
            this.Lbl_HoTen.Location = new System.Drawing.Point(16, 48);
            this.Lbl_HoTen.Name = "Lbl_HoTen";
            this.Lbl_HoTen.Size = new System.Drawing.Size(62, 22);
            this.Lbl_HoTen.TabIndex = 0;
            this.Lbl_HoTen.Text = "Họ tên";
            // 
            // Frm_QuanLyNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Pnl_ThongTinCaNhan);
            this.Controls.Add(this.Pnl_ThongTinHoaDon);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_QuanLyNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_QuanLyNguoiDung";
            this.Pnl_ThongTinHoaDon.ResumeLayout(false);
            this.Pnl_ThongTinHoaDon.PerformLayout();
            this.Pnl_ThongTinCaNhan.ResumeLayout(false);
            this.Pnl_ThongTinCaNhan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_ThongTinHoaDon;
        private System.Windows.Forms.Panel Pnl_ThongTinCaNhan;
        private System.Windows.Forms.TextBox Txt_SoDienThoaiTraCuu;
        private System.Windows.Forms.Label Lbl_HoTen;
        private System.Windows.Forms.Label Lbl_Email;
        private System.Windows.Forms.TextBox Txt_Email;
        private System.Windows.Forms.TextBox Txt_HoTen;
        private System.Windows.Forms.Button Btn_TraCuu;
        private System.Windows.Forms.Panel Pnl_DanhSachHoaDon;
        private System.Windows.Forms.TextBox Txt_MaNguoiDung;
        private System.Windows.Forms.Label Lbl_MaNguoiDung;
    }
}