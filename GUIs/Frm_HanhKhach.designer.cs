namespace QuanLyBanVeMayBay.GUIs
{
    partial class Frm_HanhKhach
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
            this.Pnl_TreEm = new System.Windows.Forms.Panel();
            this.Nud_TreEm = new System.Windows.Forms.NumericUpDown();
            this.Lbl_TreEm = new System.Windows.Forms.Label();
            this.Pnl_NguoiLon = new System.Windows.Forms.Panel();
            this.Nud_NguoiLon = new System.Windows.Forms.NumericUpDown();
            this.Lbl_NguoiLon = new System.Windows.Forms.Label();
            this.Btn_Chon = new System.Windows.Forms.Button();
            this.Pnl_TreEm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_TreEm)).BeginInit();
            this.Pnl_NguoiLon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_NguoiLon)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_TreEm
            // 
            this.Pnl_TreEm.Controls.Add(this.Nud_TreEm);
            this.Pnl_TreEm.Controls.Add(this.Lbl_TreEm);
            this.Pnl_TreEm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_TreEm.Location = new System.Drawing.Point(2, 102);
            this.Pnl_TreEm.Name = "Pnl_TreEm";
            this.Pnl_TreEm.Size = new System.Drawing.Size(360, 89);
            this.Pnl_TreEm.TabIndex = 2;
            // 
            // Nud_TreEm
            // 
            this.Nud_TreEm.Location = new System.Drawing.Point(230, 31);
            this.Nud_TreEm.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Nud_TreEm.Name = "Nud_TreEm";
            this.Nud_TreEm.Size = new System.Drawing.Size(120, 30);
            this.Nud_TreEm.TabIndex = 2;
            // 
            // Lbl_TreEm
            // 
            this.Lbl_TreEm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_TreEm.Location = new System.Drawing.Point(10, 32);
            this.Lbl_TreEm.Name = "Lbl_TreEm";
            this.Lbl_TreEm.Size = new System.Drawing.Size(162, 28);
            this.Lbl_TreEm.TabIndex = 1;
            this.Lbl_TreEm.Text = "Trẻ em (<14 tuổi)";
            // 
            // Pnl_NguoiLon
            // 
            this.Pnl_NguoiLon.Controls.Add(this.Nud_NguoiLon);
            this.Pnl_NguoiLon.Controls.Add(this.Lbl_NguoiLon);
            this.Pnl_NguoiLon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_NguoiLon.Location = new System.Drawing.Point(2, 7);
            this.Pnl_NguoiLon.Name = "Pnl_NguoiLon";
            this.Pnl_NguoiLon.Size = new System.Drawing.Size(360, 89);
            this.Pnl_NguoiLon.TabIndex = 1;
            // 
            // Nud_NguoiLon
            // 
            this.Nud_NguoiLon.Location = new System.Drawing.Point(230, 30);
            this.Nud_NguoiLon.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Nud_NguoiLon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_NguoiLon.Name = "Nud_NguoiLon";
            this.Nud_NguoiLon.Size = new System.Drawing.Size(120, 30);
            this.Nud_NguoiLon.TabIndex = 2;
            this.Nud_NguoiLon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Lbl_NguoiLon
            // 
            this.Lbl_NguoiLon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NguoiLon.Location = new System.Drawing.Point(10, 31);
            this.Lbl_NguoiLon.Name = "Lbl_NguoiLon";
            this.Lbl_NguoiLon.Size = new System.Drawing.Size(98, 28);
            this.Lbl_NguoiLon.TabIndex = 0;
            this.Lbl_NguoiLon.Text = "Người lớn";
            // 
            // Btn_Chon
            // 
            this.Btn_Chon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Chon.Location = new System.Drawing.Point(144, 197);
            this.Btn_Chon.Name = "Btn_Chon";
            this.Btn_Chon.Size = new System.Drawing.Size(75, 46);
            this.Btn_Chon.TabIndex = 3;
            this.Btn_Chon.Text = "Chọn";
            this.Btn_Chon.UseVisualStyleBackColor = true;
            this.Btn_Chon.Click += new System.EventHandler(this.Btn_Chon_Click);
            // 
            // Frm_HanhKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(364, 258);
            this.Controls.Add(this.Btn_Chon);
            this.Controls.Add(this.Pnl_TreEm);
            this.Controls.Add(this.Pnl_NguoiLon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_HanhKhach";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hành Khách";
            this.Pnl_TreEm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_TreEm)).EndInit();
            this.Pnl_NguoiLon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_NguoiLon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_TreEm;
        private System.Windows.Forms.Panel Pnl_NguoiLon;
        private System.Windows.Forms.Label Lbl_NguoiLon;
        private System.Windows.Forms.Label Lbl_TreEm;
        private System.Windows.Forms.Button Btn_Chon;
        public System.Windows.Forms.NumericUpDown Nud_TreEm;
        public System.Windows.Forms.NumericUpDown Nud_NguoiLon;
    }
}